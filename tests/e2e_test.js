import { Selector } from 'testcafe';

fixture `Calculator E2E Test`
    .page `http://localhost:3000`;

test('Addition Test', async t => {
    await t
        .click(Selector('#button-2'))
        .click(Selector('#button-+'))
        .click(Selector('#button-3'))
        .click(Selector('#button-='))
        .expect(Selector('#result').value).eql('5');
});