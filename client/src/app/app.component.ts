import { Component } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { OnInit } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'client';
  fruits : any;
  textSearch: string = "";
  model : any = {}
  constructor(private http : HttpClient){
  }
  ngOnInit(): void {
    this.getData();
  }
getData(){
  this.http.get('https://localhost:5001/Home').subscribe((response) => {
      this.fruits = response;
  },(error) => {
    console.log(error)
  })

}

search(){
  this.http.get('https://localhost:5001/Home/search?name='+this.textSearch).subscribe((response) => {
    console.log(response);
    this.fruits = response;
},error =>{
  console.log(error);
})
}

add() {
  this.http.post('https://localhost:5001/Home/Add',this.model).subscribe((response) => {
    this.getData();
  },error =>{
    console.log(error);
  })
}
}
