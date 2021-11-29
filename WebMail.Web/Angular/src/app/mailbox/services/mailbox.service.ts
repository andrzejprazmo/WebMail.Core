import { Injectable } from '@angular/core';
import { HttpService } from '@shared/services/http.service';
import { Observable } from 'rxjs';
import { MailPackageContract, MailBodyContract, FolderPackageContract } from '../models/mailbox.models';

@Injectable({
  providedIn: 'root'
})
export class MailboxService {

  constructor(private http: HttpService) { }

  getFolders(): Observable<FolderPackageContract> {
    return this.http.get<FolderPackageContract>('api/mailbox/folders');
  }

  getMailHeaders(folderName: string): Observable<MailPackageContract> {
    return this.http.get<MailPackageContract>('api/mailbox/list', { params: { 'folderName': folderName } });
  }

  getMailBody(folderName: string, mailIndex: number): Observable<MailBodyContract> {
    return this.http.get<MailBodyContract>('api/mailbox/body', {
      params: {
        'folderName': folderName, 'mailIndex': mailIndex
      }
    });
  }
}
