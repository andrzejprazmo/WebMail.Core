import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { HttpService } from '@shared/services/http.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MailPackageContract, MailBodyContract, FolderPackageContract } from '../models/mailbox.models';

@Injectable({
  providedIn: 'root'
})
export class MailboxService {

  constructor(private http: HttpService, private translateService: TranslateService) { }

  getFolders(): Observable<FolderPackageContract> {
    return this.http.get<FolderPackageContract>('api/mailbox/folders').pipe(map(value => {
      for (const folder of value.folders) {
        const folderName = `mailbox.folders.${folder.folderName}`;
        this.translateService.get(folderName).subscribe(data => {
          folder.displayName = data == folderName ? folder.folderName : data;
        });
      }
      return value;
    }));
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
