import { Component, Injector, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BroadcastService, MsalService } from '@azure/msal-angular';
import { Logger, CryptoUtils } from 'msal';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  static authService: MsalService;
  title = 'Exam';
  isIframe = false;
  loggedIn = false;
  getusername:any;
  navLinks: any[];
  activeLinkIndex = -1;
  roles: any;
  public subscription!: Subscription;
  public isLoggedIn = false;
  public isAuthorized = true;
  public isAdmin = false;
  public isDeveloper= false;
  public isReader = false;
  headerInfo:any;
  public isCandidate=false;
  isQuiz=false;
  isInterviewEvaluationForm=false;
  isNewCandidate=false;
  isMenu=false;
  constructor(private broadcastService: BroadcastService, private authService: MsalService,private router:Router,private injector: Injector) {
    AppComponent.authService = this.injector.get(MsalService);

   }

  ngOnInit() {
    this.isIframe = window !== window.parent && !window.opener;
    var domain = location.href;
    if(domain.includes("app-login-user"))
    {
        this.isCandidate=true;
        this.isMenu=true;
        this.isQuiz=false;
        this.isInterviewEvaluationForm=false;
        this.isNewCandidate=false;
    }
    if(domain.includes("quiz"))
    {
        this.isQuiz=true;
        this.isMenu=true;
        this.isCandidate=false;
        this.isInterviewEvaluationForm=false;
        this.isNewCandidate=false;
    }
    if(domain.includes("interview-evaluation"))
    {
        this.isQuiz=false;
        this.isMenu=true;
        this.isCandidate=false;
        this.isInterviewEvaluationForm=true;
        this.isNewCandidate=false;
    }
    if(domain.includes("new-candidate"))
    {
        this.isQuiz=false;
        this.isMenu=true;
        this.isCandidate=false;
        this.isInterviewEvaluationForm=false;
        this.isNewCandidate=true;
    }

    this.checkAccount();

    if (this.loggedIn) {
      var userData = this.getAccount();
      this.roles = userData.idToken.roles;

      if (this.roles !== undefined && this.roles.length > 0) {
        this.isAuthorized = this.roles.find((x: string) => x.toLowerCase() === "admin" || x.toLowerCase() === "developer").length > 0;
        if (this.roles.find((x: string) => x.toLowerCase() === "admin"))
          this.isAdmin = true;
        else if (this.roles.find((x: string) => x.toLowerCase() ===  "developer"))
          this.isDeveloper = true;
        else
          this.isAuthorized = false;//this.roles.find((x: string) => x.toLowerCase() === "support" || x.toLowerCase() === "superuser" || x.toLowerCase() === "reader").length > 0;
      }
      else
      {
        this.isAuthorized = false;
      }
      this.headerInfo = {
        userName: userData.userName,
        name: userData.name,
        isLoggedIn: this.loggedIn
      }

      this.getusername=userData.name;
      if(this.isAuthorized)
      {
        let key= userData.name;
        localStorage.setItem('Blog',key);
        this.router.navigate(['/users']);
      }
    }
    else {
      this.headerInfo = {
        userName: "",
        name: "",
        isLoggedIn: this.loggedIn
      }
    }

    this.broadcastService.subscribe('msal:loginSuccess', () => {
      this.checkAccount();
    });

    this.authService.handleRedirectCallback((authError, response) => {

      if (authError) {
        console.error('Redirect Error: ', authError.errorMessage);
        return;
      }

      console.log('Redirect Success: ', response.accessToken);
    });

    this.authService.setLogger(new Logger((logLevel, message, piiEnabled) => {

      console.log('MSAL Logging: ', message);
      if(message.includes("Processing the callback from redirect response"))
      {
        location.reload();
      }

    }, {

      correlationId: CryptoUtils.createNewGuid(),
      piiLoggingEnabled: false
    }));
  }

  checkAccount() {

    this.loggedIn = !!AppComponent.authService.getAccount();
  }
  getAccount() {

    return AppComponent.authService.getAccount();
  }

  login() {

    const isIE = window.navigator.userAgent.indexOf('MSIE ') > -1 || window.navigator.userAgent.indexOf('Trident/') > -1;

    if (isIE) {


      AppComponent.authService.loginRedirect();
    } else {

      AppComponent.authService.loginPopup();
    }
  }

  logout() {
    this.authService.logout();
  }
}
