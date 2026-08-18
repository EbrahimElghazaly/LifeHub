import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  model = {
    fullName: '',
    email: '',
    password: '',
    confirmPassword: ''
  };
  loading = false;
  error = '';
  success = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  onSubmit(): void {
    if (this.model.password !== this.model.confirmPassword) {
      this.error = 'كلمة المرور غير متطابقة';
      return;
    }

    this.loading = true;
    this.error = '';
    this.success = '';

    const registerData = {
      fullName: this.model.fullName,
      email: this.model.email,
      password: this.model.password
    };

    this.authService.register(registerData).subscribe({
      next: () => {
        this.success = 'تم إنشاء الحساب بنجاح! جاري تحويلك...';
        setTimeout(() => {
          this.router.navigate(['/login']);
        }, 2000);
        this.loading = false;
      },
      error: (err) => {
        this.error = 'حدث خطأ. حاول مرة أخرى.';
        this.loading = false;
        console.error('Register error:', err);
      }
    });
  }
}