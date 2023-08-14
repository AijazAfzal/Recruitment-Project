import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-new-candidate',
  templateUrl: './new-candidate.component.html',
  styleUrls: ['./new-candidate.component.css']
})
export class NewCandidateComponent implements OnInit {
  loading: boolean;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }
  postdata() {
    debugger
    var name = (<any>(document.getElementById('txtName'))).value;
    var mobile = (<any>(document.getElementById('txtmob'))).value;
    var email = (<any>(document.getElementById('txtemail'))).value;
    var qualification = (<any>(document.getElementById('ddlsource'))).value;
    var communication = (<any>(document.getElementById('txtCommunication'))).value;
    var logical = (<any>(document.getElementById('txtLogical'))).value;
    var coding = (<any>(document.getElementById('txtCoding'))).value;
    var myDate = new Date().toISOString();
    var datetimevalue = myDate.substring(0, myDate.length - 1);
    var result = { UserName: name, MobileNo: mobile, Email: email, CreatedDate: datetimevalue, ExamStatus: 1,Source:6,SourceName:'Bhadruka College',Technology:1,Qualification:qualification,CommunicationRating:communication,LogicalRating:logical,CodingRating:coding};
    debugger
    this.http.post<any>('https://ariqtonlineexamappapi.azurewebsites.net/api/User', result).subscribe(data => {
debugger
        if (data.userId > 0) {
          this.http.post<any>('https://ariqtonlineexamappapi.azurewebsites.net/api/User/sendemail', data).subscribe(data => {
            debugger
            alert("Successfully Registered, Please check your Email");
            window.self.close();
          },
          )
        }
        else {
          alert("This candidate is already exists");
        }

      },
      )
    }
  }
