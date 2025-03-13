'use client';

import React, { createContext, useState, useEffect, ReactNode } from 'react';
import { ThemeProvider as StyledThemeProvider } from 'styled-components';

interface ThemeProps {
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

interface ThemeContextProps {
  theme: ThemeProps;
  toggleTheme: () => void;
}

interface ThemeProviderProps {
  children: ReactNode;
}

const lightTheme: ThemeProps = {
  primary: '#7c3aed', // violet
  secondary: '#3b82f6', // blue
  background: '#ffffff',
  cardBackground: '#f9fafb',
  text: '#111827',
  inputBorder: '#d1d5db',
  inputBackground: '#ffffff',
  buttonText: '#ffffff',
  isDark: false
};

const darkTheme: ThemeProps = {
  primary: '#8b5cf6', // lighter violet for dark mode
  secondary: '#60a5fa', // lighter blue for dark mode
  background: '#111827',
  cardBackground: '#1f2937',
  text: '#f9fafb',
  inputBorder: '#374151',
  inputBackground: '#1f2937',
  buttonText: '#ffffff',
  isDark: true
};

export const ThemeContext = createContext<ThemeContextProps>({
  theme: lightTheme,
  toggleTheme: () => {}
});

export const ThemeProvider: React.FC<ThemeProviderProps> = ({ children }) => {
  const [isDarkMode, setIsDarkMode] = useState<boolean>(false);
  
  useEffect(() => {
    const savedTheme = localStorage.getItem('theme');
    if (savedTheme === 'dark') {
      setIsDarkMode(true);
    }
  }, []);
  
  const toggleTheme = (): void => {
    setIsDarkMode(!isDarkMode);
    localStorage.setItem('theme', !isDarkMode ? 'dark' : 'light');
  };
  
  const theme = isDarkMode ? darkTheme : lightTheme;
  
  return (
    <ThemeContext.Provider value={{ theme, toggleTheme }}>
      <StyledThemeProvider theme={theme}>
        {children}
      </StyledThemeProvider>
    </ThemeContext.Provider>
  );
}; 