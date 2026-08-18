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
    // التحقق من تطابق كلمة المرور
    if (this.model.password !== this.model.confirmPassword) {
      this.error = 'كلمة المرور غير متطابقة';
      return;
    }

    // التحقق من أن الحقول مليانة
    if (!this.model.fullName.trim()) {
      this.error = 'الاسم الكامل مطلوب';
      return;
    }

    if (!this.model.email.trim()) {
      this.error = 'البريد الإلكتروني مطلوب';
      return;
    }

    if (!this.model.password || this.model.password.length < 6) {
      this.error = 'كلمة المرور يجب أن تكون 6 أحرف على الأقل';
      return;
    }

    this.loading = true;
    this.error = '';
    this.success = '';

    const registerData = {
      fullName: this.model.fullName.trim(),
      email: this.model.email.trim(),
      password: this.model.password
    };

    this.authService.register(registerData).subscribe({
      next: () => {
        this.success = 'تم إنشاء الحساب بنجاح! جاري تحويلك...';
        this.loading = false;
        setTimeout(() => {
          this.router.navigate(['/login']);
        }, 2000);
      },
      error: (err) => {
        console.error('Register error:', err);
        
        // رسائل خطأ من الـ API
        if (err.error && err.error.errors) {
          // لو فيه validation errors من الـ API
          const errors = Object.values(err.error.errors).flat();
          this.error = errors.join(' ');
        } else if (err.error && typeof err.error === 'string') {
          this.error = err.error;
        } else if (err.error && err.error.message) {
          this.error = err.error.message;
        } else {
          this.error = 'حدث خطأ. تأكد من صحة البيانات وحاول مرة أخرى.';
        }
        
        this.loading = false;
      }
    });
  }
}