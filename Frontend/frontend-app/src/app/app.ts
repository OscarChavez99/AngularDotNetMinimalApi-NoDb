import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

import { User } from './interfaces/user';
import { UserService } from './services/user-service';

@Component({
  selector: 'app-root',
  imports: [MatTableModule,
    ReactiveFormsModule, 
    MatFormFieldModule, 
    MatInputModule, 
    MatButtonModule
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  users: User[] = [];
  userForm: FormGroup;
  protected title = 'frontend-app';

  constructor (private userService: UserService, private formGroup: FormBuilder) {
    this.userForm = this.formGroup.group ({
      id: 3,
      name: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getUsers().subscribe(data => {
      this.users = data;
    });
  }

  addUser(): void {
    this.userService.addUser(this.userForm.value).subscribe(data => {
      console.log("User added: ", data)
    });
  }

  onSubmit(): void {
    if (this.userForm.valid) {
      this.addUser();
    }
  }
}
