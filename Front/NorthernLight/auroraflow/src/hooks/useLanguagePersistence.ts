'use client';

import { useEffect } from 'react';
import i18n from '@/i18n';

export const useLanguagePersistence = () => {
  useEffect(() => {
    // Load the saved language from localStorage on mount
    const savedLanguage = localStorage.getItem('i18nextLng');
    
    if (savedLanguage && i18n.language !== savedLanguage) {
      i18n.changeLanguage(savedLanguage);
    }
    
    // Save language to localStorage when it changes
    const handleLanguageChanged = (lng: string) => {
      localStorage.setItem('i18nextLng', lng);
    };
    
    i18n.on('languageChanged', handleLanguageChanged);
    
    return () => {
      i18n.off('languageChanged', handleLanguageChanged);
    };
  }, []);
  
  return null;
};

export default useLanguagePersistence; 