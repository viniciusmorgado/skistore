import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';

@Component({
  selector: 'app-errors',
  imports: [],
  templateUrl: './errors.component.html',
  styleUrl: './errors.component.css'
})
export class ErrorsComponent {
  baseUrl = 'http://localhost:5001/api/'
  private http = inject(HttpClient);

  get401Error() {
    this.http.get(this.baseUrl + '_buggy/unauthorized').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }

  get400Error() {
    this.http.get(this.baseUrl + '_buggy/bad-request').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }

  get404Error() {
    this.http.get(this.baseUrl + '_buggy/notfound').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }

  getInternalError() {
    this.http.get(this.baseUrl + '_buggy/internalerror').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }

  getValidationError() {
    this.http.get(this.baseUrl + '_buggy/secret').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }
}
