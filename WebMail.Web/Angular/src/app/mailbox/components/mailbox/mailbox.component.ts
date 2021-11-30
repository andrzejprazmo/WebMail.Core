import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthorizeService, TokenContract } from '@auth/services/authorize.service';
import { FolderContract, MailBodyContract, MailHeaderContract } from '@mailbox/models/mailbox.models';
import { MailboxService } from '@mailbox/services/mailbox.service';
import { MailboxBodyComponent } from './mailbox-body/mailbox-body.component';
import { MailboxFoldersComponent } from './mailbox-folders/mailbox-folders.component';

@Component({
  selector: 'app-mailbox',
  templateUrl: './mailbox.component.html',
  styleUrls: ['./mailbox.component.css']
})
export class MailboxComponent implements OnInit {
  @ViewChild('folderListComponent') folderListComponent!: MailboxFoldersComponent;
  @ViewChild('mailBodyComponent') mailBodyComponent!: MailboxBodyComponent;

  folderList: FolderContract[] = [];
  mailItemList: MailHeaderContract[] = [];
  currentFolderName: string = '';
  currentMailBody!: MailBodyContract | null;

  public get currentUser(): TokenContract | null {
    return this.authService.getUser();
  }

  constructor(private authService: AuthorizeService, private mailboxService: MailboxService) { }

  ngOnInit(): void {
    this.mailboxService.getFolders().subscribe(result => {
      this.folderList = result.folders;
      this.folderListComponent.selectInboxFolder();
    });
  }

  onFolderChange(folderName: string) {
    this.currentFolderName = folderName;
    this.mailboxService.getMailHeaders(folderName).subscribe(result => {
      this.mailItemList = result.list;
      this.currentMailBody = null;
    });
  }

  onMailSelected(mailItem: MailHeaderContract) {
    this.mailboxService.getMailBody(this.currentFolderName, mailItem.index).subscribe(result => {
      this.currentMailBody = result;
    });
  }
}
