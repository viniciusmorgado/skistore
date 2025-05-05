import { Component } from '@angular/core';
import { MatIcon } from '@angular/material/icon'
import { MatButton } from '@angular/material/button'
import { MatBadge } from '@angular/material/badge'
import { RouterLink } from '@angular/router';
import { NavbarComponent } from "../navbar/navbar.component";

@Component({
  selector: 'app-header',
  imports: [
    MatIcon,
    MatButton,
    MatBadge,
    RouterLink,
    NavbarComponent
],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})

export class HeaderComponent {

}
