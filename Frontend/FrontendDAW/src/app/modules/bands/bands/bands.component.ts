import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-bands',
  templateUrl: './bands.component.html',
  styleUrls: ['./bands.component.scss'],
})
export class BandsComponent implements OnInit, OnDestroy {
  public subscription: Subscription;
  public loggedUser;
  public parentMessage = 'message from parent';
  constructor(private router: Router, private dataService: DataService) {}

  ngOnInit() {
    this.subscription = this.dataService.currentUser.subscribe(
      (user) => (this.loggedUser = user)
    );
  }
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  public logout(): void {
    localStorage.setItem('Role', 'Anonim');
    this.router.navigate(['/login']);
  }

  public receiveMessage(event): void {
    console.log(event);
  }
}
