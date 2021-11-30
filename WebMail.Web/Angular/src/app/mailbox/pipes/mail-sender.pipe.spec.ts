import { MailSenderPipe } from './mail-sender.pipe';

describe('MailSenderPipe', () => {
  it('create an instance', () => {
    const pipe = new MailSenderPipe();
    expect(pipe).toBeTruthy();
  });
});
