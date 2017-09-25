import { browser, by, element } from 'protractor';

export class AppPage {
  navigateTo() {
    return browser.get('http://localhost:4200/home-control/supervisor/reassignment-list');
  }

  getParagraphText() {
    return element(by.css('app-root h1')).getText();
  }
}
