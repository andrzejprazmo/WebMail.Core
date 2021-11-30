import { Pipe, PipeTransform } from '@angular/core';
import { MailAddress } from '../models/mailbox.models';

@Pipe({
  name: 'mailSender'
})
export class MailSenderPipe implements PipeTransform {

  transform(list: MailAddress[], format?: string): string {
    if (list) {
      return list.map((v, i) => {
        switch (format) {
          case 'n':
            return v.name ? v.name : v.address;
          case 'a':
            return v.address;
          default:
            return `${v.name} <${v.address}>`;
        }
      }).join(',');
    }
    return '';
  }

}
