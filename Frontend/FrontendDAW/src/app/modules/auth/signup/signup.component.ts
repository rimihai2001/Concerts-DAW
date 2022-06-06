import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { DataService } from 'src/app/services/data.service';
import { LoginserverService } from 'src/app/services/loginserver.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent implements OnInit, OnDestroy {
  public message;
  public subscription: Subscription;

  public registerForm: FormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
    role: new FormControl(''),
  });
  constructor(
    private router: Router,
    private dataService: DataService,
    private logins: LoginserverService
  ) {}

  get emailr(): AbstractControl {
    return this.registerForm.get('email');
  }
  get passwordr(): AbstractControl {
    return this.registerForm.get('password');
  }
  get roler(): AbstractControl {
    return this.registerForm.get('role');
  }

  ngOnInit() {
    
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  public register(): void {
    this.logins.register(this.registerForm.value).subscribe(
      (result) => {
        alert('Succes');
      },
      (error) => {
        alert('Eroare Register');
      }
    );
  }
}
