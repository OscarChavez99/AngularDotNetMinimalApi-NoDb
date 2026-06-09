import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { User } from './interfaces/user';
import { UserService } from './services/user-service';

@Component({
  selector: 'app-root',
  imports: [MatTableModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  users: User[] = [
    {id: 1, name: "Oscar"},
    {id: 2, name: "Fabian"},
  ];
  protected title = 'frontend-app';

  constructor (private userService: UserService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getUsers().subscribe(data => {
      this.users = data;
    });
  }
}
