import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MailboxComponent } from './components/mailbox/mailbox.component';
import { SharedModule } from '@shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MailboxListComponent } from './components/mailbox/mailbox-list/mailbox-list.component';
import { MailboxFoldersComponent } from './components/mailbox/mailbox-folders/mailbox-folders.component';
import { MailboxBodyComponent } from './components/mailbox/mailbox-body/mailbox-body.component';
import { MailboxListToolbarComponent } from './components/mailbox/mailbox-list-toolbar/mailbox-list-toolbar.component';
import { TranslateModule } from '@ngx-translate/core';
import { MailSenderPipe } from './pipes/mail-sender.pipe';



@NgModule({
  declarations: [
    MailboxComponent,
    MailboxListComponent,
    MailboxFoldersComponent,
    MailboxBodyComponent,
    MailboxListToolbarComponent,
    MailSenderPipe
  ],
  imports: [
    CommonModule, SharedModule, FormsModule, ReactiveFormsModule, TranslateModule.forChild()
  ]
})
export class MailboxModule { }
