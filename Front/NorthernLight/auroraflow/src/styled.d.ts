import 'styled-components';

declare module 'styled-components' {
  export interface DefaultTheme {
    primary: string;
    secondary: string;
    background: string;
    cardBackground: string;
    text: string;
    inputBorder: string;
    inputBackground: string;
    buttonText: string;
    isDark: boolean;
  }
} 