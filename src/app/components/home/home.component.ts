import { Component, OnInit } from '@angular/core';
import {CdkDragDrop, moveItemInArray, transferArrayItem} from '@angular/cdk/drag-drop';
import { TodoService } from 'src/app/services/todo.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  data={
    doo : [
    ],
  
    doing : [
    ],
    done : [
    ]
  }
  
  constructor(
    private todoService:TodoService
  ) { }

  ngOnInit() {
   // this.setItems();
    this.getAll();
  }
  drop(event: CdkDragDrop<string[]>) {
    if (event.previousContainer === event.container) {
      moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
    } else {
      transferArrayItem(event.previousContainer.data,
                        event.container.data,
                        event.previousIndex,
                        event.currentIndex);
    }
    console.log(this.data);
    this.todoService.updateTodo(this.data)
      .subscribe((res)=>{
        //console.log(res);
      },(err)=>{
        //console.log(err);
      });
    /*Object.keys(this.data).forEach((key)=>{
      localStorage.setItem(key,JSON.stringify(this.data[key]));
    });*/
  }
  addTodo(a){
    this.data.doo.push(a.value);
    a.value="";
    //console.log(this.data);
    this.todoService.updateTodo(this.data)
      .subscribe((res)=>{
        //console.log(res);
      },(err)=>{
        //console.log(err);
      });
    
  }
  /*setItems(){
    Object.keys(this.data).forEach((key)=>{
      if(!localStorage.getItem(key)){
        localStorage.setItem(key,JSON.stringify(this.data[key]));
      }
      else
        this.data[key]=JSON.parse(localStorage.getItem(key));
    });

  }*/
  getAll(){
    this.todoService.getAllTodos()
      .subscribe((res)=>{
        
        Object.keys(res[0]).forEach((key)=>{
          if(key=='doo'||key=='doing'||key=='done'||key=='id')
            this.data[key]=res[0][key];
          
        });
        //console.log(this.data);
      },(err)=>{
        //console.log(err);
      });
  }
}
