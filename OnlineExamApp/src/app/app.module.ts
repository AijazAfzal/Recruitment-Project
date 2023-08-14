import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MsalModule, MsalInterceptor } from '@azure/msal-angular';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ProfileComponent } from './profile/profile.component';
import { HomeComponent } from './home/home.component';
import {nl2brPipe} from './nl2br.pipe';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { QuizComponent } from './quiz/quiz.component';
import { LoginUserComponent } from './login-user/login-user.component';
import { UsersComponent } from './users/users.component';
import { AdminComponent } from './admin/admin.component';
import { QuestionsComponent } from './questions/questions.component';
import { RouterModule } from '@angular/router';
import { MenuBarComponent } from './menu-bar/menu-bar.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { HeaderComponent } from './header/header.component';
import { EditQuestionComponent } from './edit-question/edit-question.component';
import { PostQuestionComponent } from './post-question/post-question.component';
import { AddCandidateComponent } from './add-candidate/add-candidate.component';
import { ScheduleInterviewComponent } from './schedule-interview/schedule-interview.component';
import { CandidateProfileComponent } from './candidate-profile/candidate-profile.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { InterviewEvaluationFormComponent } from './interview-evaluation-form/interview-evaluation-form.component';
import { NewCandidateComponent } from './new-candidate/new-candidate.component';
const isIE = window.navigator.userAgent.indexOf('MSIE ') > -1 || window.navigator.userAgent.indexOf('Trident/') > -1;

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,
    HomeComponent,
    nl2brPipe,
    QuizComponent,
    LoginUserComponent,
    UsersComponent,
    QuestionsComponent,
    AdminComponent,
    MenuBarComponent,
    UnauthorizedComponent,
    HeaderComponent,
    EditQuestionComponent,
    PostQuestionComponent,
    AddCandidateComponent,
    ScheduleInterviewComponent,
    CandidateProfileComponent,
    InterviewEvaluationFormComponent,
    NewCandidateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatProgressSpinnerModule,
    HttpClientModule,
    MatToolbarModule,
    ReactiveFormsModule,
    NgbModule,
    MatButtonModule,
    FormsModule,
    MatListModule,
    AppRoutingModule,
    RouterModule.forRoot([]),
    MsalModule.forRoot({
      auth: {
        clientId: '986e8be4-2f68-48e1-9ad4-a98ec77c0e38',
        authority: 'https://login.microsoftonline.com/8f6bd982-92c3-4de0-985d-0e287c55e379/',
        //redirectUri: 'https://localhost:4200',
        //redirectUri: 'https://ariqtexamportal.azurewebsites.net',
        redirectUri: 'https://recruit.ariqt.com',
      },
      cache: {
        cacheLocation: 'localStorage',
        storeAuthStateInCookie: isIE, // set to true for IE 11
      },
    },
    {
      popUp: !isIE,
      consentScopes: [
        'user.read',
        'openid',
        'profile',
      ],
      unprotectedResources: [],
      protectedResourceMap: [
        ['https://graph.microsoft.com/v1.0/me', ['user.read']]
      ],
      extraQueryParameters: {}
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
