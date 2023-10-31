import LanguageRo from './messages/ro.json';
import LanguageEn from './messages/en.json';

const INITIAL_LOCALE = 'ro';

const MESSAGES = {
  ro: LanguageRo,
  en: LanguageEn,
};

const SUPPORTED_LOCALES = {
  ro: 'Romana',
  en: 'English',
};

export { MESSAGES, SUPPORTED_LOCALES, INITIAL_LOCALE };
