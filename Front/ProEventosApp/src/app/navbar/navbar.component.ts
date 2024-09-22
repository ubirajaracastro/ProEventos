import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  isCollapsed = true;
  constructor(private router: Router) { }

  showMenu(): boolean {
    return this.router.url !== '/user/login';
  }




  
}
