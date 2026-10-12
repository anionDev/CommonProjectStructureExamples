import { expect, Page } from '@playwright/test';
import { saveLayoutOfPage } from './PageLayout';

/*
 * Opens the given route and compares the resulting screenshot with the baseline-screenshot
 * which belongs to the current browser and operating-system.
 * The comparison-tolerance is defined centrally in playwright.config.ts.
 */
export async function expectPageToLookLikeBaseline(page: Page, route: string, baselineName: string): Promise<void> {
    await openPageInReproducibleState(page, route);
    await expect(page).toHaveScreenshot(`${baselineName}.png`, {
        fullPage: true,
        caret: 'hide',
        animations: 'disabled'
    });
    /*
     * The screenshot above is only compared with the baseline of the same browser, which can not detect that a
     * page looks different in one browser than in the others. The geometry of the page is therefore written
     * down additionally; it is compared across the browsers after the run (see saveLayoutOfPage).
     */
    await saveLayoutOfPage(page, baselineName);
}

/*
 * The font which is used on every page. A page which is rendered before this font is available looks completely
 * different, so a screenshot which is taken at that moment does not differ from its baseline by a few pixels but
 * by a large part of the image. The font is delivered with the application, so it is available immediately; the
 * check is kept nevertheless, because it makes a missing font fail with a clear message instead of with a
 * difference of the whole page, which would look like a regression of the user-interface.
 */
const requiredFont: string = '16px Roboto';

/*
 * Navigates to the given route and waits until the page is rendered completely.
 * Without this waiting the screenshots would be flaky.
 */
async function openPageInReproducibleState(page: Page, route: string): Promise<void> {
    await page.goto(route, { waitUntil: 'networkidle' });
    await page.evaluate(() => document.fonts.ready);
    /*
     * Waiting for "document.fonts.ready" alone is not sufficient: it also resolves if the loading of a font
     * failed. Therefore it is checked explicitly that the required font is really usable now.
     */
    await page.waitForFunction((font: string) => document.fonts.check(font), requiredFont);
}
