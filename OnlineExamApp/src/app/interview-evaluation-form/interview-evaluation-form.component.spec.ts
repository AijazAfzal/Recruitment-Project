import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewEvaluationFormComponent } from './interview-evaluation-form.component';

describe('InterviewEvaluationFormComponent', () => {
  let component: InterviewEvaluationFormComponent;
  let fixture: ComponentFixture<InterviewEvaluationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InterviewEvaluationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewEvaluationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
