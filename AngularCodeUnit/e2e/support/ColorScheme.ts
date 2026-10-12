import { Page } from '@playwright/test';

/* The color-schemes which the application supports. (See the color-scheme-toggle-button.) */
export type ColorScheme = 'system' | 'light' | 'dark';

/*
 * The key under which the color-scheme-toggle-button stores the chosen scheme. It is duplicated here on
 * purpose: the testcases use the application from the outside and therefore must not import its sourcecode.
 */
const storageKeyOfTheColorScheme: string = 'theme';

/*
 * Makes the application behave as if the user chose the given color-scheme earlier.
 *
 * This example-application has no backend which could store the choice of a user, so the value is written into
 * the storage of the browser, which is where the toggle-button keeps it. It has to be written before the
 * application is loaded, because the button applies the stored value while it is starting.
 */
export async function simulateChosenColorScheme(page: Page, colorScheme: ColorScheme): Promise<void> {
    await page.addInitScript((chosenScheme: { key: string, value: string }) => {
        localStorage.setItem(chosenScheme.key, chosenScheme.value);
    }, { key: storageKeyOfTheColorScheme, value: colorScheme });
}
