import { Selector } from 'testcafe';

fixture `Calculator E2E Test`
    .page `http://localhost:3000`;

test('Basic Addition Test', async t => {
    await t
        .click(Selector('#btn-2'))
        .click(Selector('#btn-+'))
        .click(Selector('#btn-3'))
        .click(Selector('#btn-='))
        .expect(Selector('input').value).eql('5');
});