'use client';

import React, { useState, useEffect } from 'react';
import i18n from '@/i18n';
import { I18nextProvider } from 'react-i18next';
import useLanguagePersistence from '@/hooks/useLanguagePersistence';

interface I18nProviderProps {
  children: React.ReactNode;
}

export const I18nProvider: React.FC<I18nProviderProps> = ({ children }) => {
  const [isInitialized, setIsInitialized] = useState(i18n.isInitialized);
  
  // Use the language persistence hook
  useLanguagePersistence();

  useEffect(() => {
    // Load translations if not already initialized
    const initI18n = async () => {
      if (!i18n.isInitialized) {
        await i18n.loadResources();
        
        // Ensure language from localStorage is applied
        const savedLanguage = localStorage.getItem('i18nextLng');
        if (savedLanguage) {
          await i18n.changeLanguage(savedLanguage);
        }
        
        setIsInitialized(true);
      }
    };

    initI18n();
  }, []);

  // Only render children once i18n is initialized
  if (!isInitialized) {
    return <div>Loading translations...</div>;
  }

  return (
    <I18nextProvider i18n={i18n}>
      {children}
    </I18nextProvider>
  );
};

export default I18nProvider; 