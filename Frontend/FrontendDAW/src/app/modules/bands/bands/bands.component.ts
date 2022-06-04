import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { BandsService } from 'src/app/services/bands.service';
import { DataService } from 'src/app/services/data.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

@Component({
  selector: 'app-bands',
  templateUrl: './bands.component.html',
  styleUrls: ['./bands.component.scss'],
})
export class BandsComponent implements OnInit, OnDestroy {
  public subscription: Subscription;
  public loggedUser;
  public parentMessage = 'message from parent';
  public Bands = [];
  public displayedColumns = ['id', 'bandName', 'musicGenre', 'yearFounded']
  


  constructor(
    private router: Router,
    private dataService: DataService,
    private bandsService: BandsService
  ) {}

  ngOnInit() {
    this.subscription = this.dataService.currentUser.subscribe(
      (user) => (this.loggedUser = user)
    );
    this.bandsService.getBands().subscribe(
      (result) => {
        console.log(result);
        this.Bands = result;
      },
      (error) => console.error(error)
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
