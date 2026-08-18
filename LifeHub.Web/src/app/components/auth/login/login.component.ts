import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  model = {
    email: '',
    password: ''
  };
  loading = false;
  error = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  onSubmit(): void {
    this.loading = true;
    this.error = '';
    
    this.authService.login(this.model).subscribe({
      next: () => {
        this.router.navigate(['/dashboard']);
        this.loading = false;
      },
      error: (err) => {
        this.error = 'البريد الإلكتروني أو كلمة المرور غير صحيحة';
        this.loading = false;
        console.error('Login error:', err);
      }
    });
  }
}