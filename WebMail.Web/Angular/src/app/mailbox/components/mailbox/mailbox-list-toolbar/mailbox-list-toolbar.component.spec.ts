import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MailboxListToolbarComponent } from './mailbox-list-toolbar.component';

describe('MailboxListToolbarComponent', () => {
  let component: MailboxListToolbarComponent;
  let fixture: ComponentFixture<MailboxListToolbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MailboxListToolbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MailboxListToolbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
