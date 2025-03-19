import i18n from 'i18next';
import { initReactI18next } from 'react-i18next';
import LanguageDetector from 'i18next-browser-languagedetector';

import enTranslation from './locales/en/translation.json';
import ruTranslation from './locales/ru/translation.json';
import kaTranslation from './locales/ka/translation.json';

// Initialize i18next once for the entire app
const i18nInstance = i18n
  .use(LanguageDetector) // Detect user language
  .use(initReactI18next) // Pass i18n down to react-i18next
  .init({
    resources: {
      en: {
        translation: enTranslation
      },
      ru: {
        translation: ruTranslation
      },
      ka: {
        translation: kaTranslation
      }
    },
    fallbackLng: 'en', // Fallback language if translation not available
    detection: {
      order: ['localStorage', 'navigator'], // First check localStorage, then browser language
      lookupLocalStorage: 'i18nextLng', // Local storage key
      caches: ['localStorage'], // Cache user language selection
    },
    interpolation: {
      escapeValue: false // React already escapes values
    },
    react: {
      useSuspense: false // Important for server-side rendering
    },
    // This is critical for page refresh - load translations immediately
    initImmediate: false
  });

// Make sure translations are loaded synchronously
if (!i18n.isInitialized) {
  i18n.loadResources();
}

export default i18n; 