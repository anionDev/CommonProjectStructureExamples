import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';

describe('AppComponent', () => {

  let fixture: ComponentFixture<AppComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppComponent],
    }).compileComponents();
    fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
  });

  it('is created', () => {
    expect(fixture.componentInstance).toBeTruthy();
  });

  it('shows its title', () => {
    const toolbar: HTMLElement | null = fixture.nativeElement.querySelector('mat-toolbar');
    expect(toolbar?.textContent).toContain('AngularCodeUnit');
  });
});
