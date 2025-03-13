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
  background: 'linear-gradient(135deg, rgba(255,255,255,0.9) 0%, rgba(249,250,251,0.95) 100%)',
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
  background: 'linear-gradient(135deg, rgba(17,24,39,0.9) 0%, rgba(31,41,55,0.95) 100%)',
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
    // Check for saved theme
    const savedTheme = localStorage.getItem('theme');
    
    // Check for system preference if no saved theme
    if (!savedTheme) {
      const prefersDark = window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches;
      setIsDarkMode(prefersDark);
    } else {
      setIsDarkMode(savedTheme === 'dark');
    }
  }, []);
  
  useEffect(() => {
    // Update the data-theme attribute on the document body
    if (isDarkMode) {
      document.body.setAttribute('data-theme', 'dark');
    } else {
      document.body.setAttribute('data-theme', 'light');
    }
  }, [isDarkMode]);
  
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