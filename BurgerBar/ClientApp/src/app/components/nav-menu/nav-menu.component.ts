import { Component, HostListener } from '@angular/core';
import { faHome, faUtensils, faQuestionCircle, faPhone, faConciergeBell, faStoreAlt } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {
  isExpanded = false;
  innerWidth: number;

  faHome = faHome;
  faUtensils = faUtensils;
  faQuestionCircle = faQuestionCircle;
  faPhone = faPhone;
  faConciergeBell = faConciergeBell;
  faStoreAlt = faStoreAlt;

  ngOnInit() {
    this.innerWidth = window.innerWidth;
  }

  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.innerWidth = window.innerWidth;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
