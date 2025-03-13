'use client';

import React from 'react';
import styled from 'styled-components';
import { useTranslation } from 'react-i18next';

const SelectContainer = styled.div`
  position: relative;
  margin-left: 1rem;
`;

const LanguageButton = styled.button`
  background-color: transparent;
  border: 1px solid ${({ theme }) => theme.inputBorder};
  border-radius: 0.375rem;
  color: ${({ theme }) => theme.text};
  cursor: pointer;
  display: flex;
  align-items: center;
  font-size: 0.79rem;
  padding: 0.5rem 0.75rem;
  transition: border-color 0.2s ease;
  
  &:hover {
    border-color: ${({ theme }) => theme.primary};
  }
`;

const DropdownMenu = styled.div<{ $isOpen: boolean }>`
  position: absolute;
  top: 100%;
  right: 0;
  width: max-content;
  min-width: 100px;
  background-color: ${({ theme }) => theme.cardBackground};
  border: 1px solid ${({ theme }) => theme.inputBorder};
  border-radius: 0.375rem;
  margin-top: 0.25rem;
  display: ${props => props.$isOpen ? 'block' : 'none'};
  z-index: 10;
  overflow: hidden;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
`;

const LanguageOption = styled.button`
  width: 100%;
  text-align: left;
  padding: 0.5rem 0.75rem;
  border: none;
  background-color: transparent;
  color: ${({ theme }) => theme.text};
  cursor: pointer;
  display: flex;
  align-items: center;
  font-size: 0.79rem;
  
  &:hover {
    background-color: ${({ theme }) => theme.background};
  }
`;

const FlagContainer = styled.span`
  display: flex;
  align-items: center;
  justify-content: center;
  width: 20px;
  height: 14px;
  margin-right: 10px;
  
  svg {
    width: 100%;
    height: 100%;
  }
`;

const LanguageInfo = styled.div`
  display: flex;
  align-items: center;
  width: 100%;
  justify-content: space-between;
`;

const LanguageAbbr = styled.span`
  font-weight: 400;
`;

interface LanguageInfo {
  code: string;
  abbr: string;
  flagIcon: React.ReactNode;
}

// SVG flag icons
const USAFlag = () => (
  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1235 650">
    <rect width="1235" height="650" fill="#bf0a30"/>
    <rect width="1235" height="50" fill="#ffffff" y="50"/>
    <rect width="1235" height="50" fill="#ffffff" y="150"/>
    <rect width="1235" height="50" fill="#ffffff" y="250"/>
    <rect width="1235" height="50" fill="#ffffff" y="350"/>
    <rect width="1235" height="50" fill="#ffffff" y="450"/>
    <rect width="1235" height="50" fill="#ffffff" y="550"/>
    <rect width="494" height="350" fill="#002868"/>
    <g fill="#ffffff">
      {Array.from({ length: 5 }).map((_, i) => (
        Array.from({ length: 6 }).map((_, j) => (
          <circle key={`${i}-${j}`} cx={41 + j * 82} cy={35 + i * 70} r="19"/>
        ))
      ))}
      {Array.from({ length: 4 }).map((_, i) => (
        Array.from({ length: 5 }).map((_, j) => (
          <circle key={`extra-${i}-${j}`} cx={82 + j * 82} cy={70 + i * 70} r="19"/>
        ))
      ))}
    </g>
  </svg>
);

const RussiaFlag = () => (
  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 9 6">
    <rect fill="#fff" width="9" height="3"/>
    <rect fill="#d52b1e" y="3" width="9" height="3"/>
    <rect fill="#0039a6" y="2" width="9" height="2"/>
  </svg>
);

const GeorgiaFlag = () => (
  <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 300 200">
    <rect width="300" height="200" fill="#fff"/>
    <path d="M 130,0 L 170,0 L 170,80 L 300,80 L 300,120 L 170,120 L 170,200 L 130,200 L 130,120 L 0,120 L 0,80 L 130,80 Z" fill="#ff0000"/>
    <path d="M 50,50 L 80,50 L 80,30 L 100,30 L 100,50 L 130,50 L 130,70 L 100,70 L 100,90 L 80,90 L 80,70 L 50,70 Z" fill="#ff0000"/>
    <path d="M 200,50 L 230,50 L 230,30 L 250,30 L 250,50 L 280,50 L 280,70 L 250,70 L 250,90 L 230,90 L 230,70 L 200,70 Z" fill="#ff0000"/>
    <path d="M 50,150 L 80,150 L 80,130 L 100,130 L 100,150 L 130,150 L 130,170 L 100,170 L 100,190 L 80,190 L 80,170 L 50,170 Z" fill="#ff0000"/>
    <path d="M 200,150 L 230,150 L 230,130 L 250,130 L 250,150 L 280,150 L 280,170 L 250,170 L 250,190 L 230,190 L 230,170 L 200,170 Z" fill="#ff0000"/>
  </svg>
);

const languages: LanguageInfo[] = [
  { 
    code: 'en', 
    abbr: 'ENG',
    flagIcon: <USAFlag />
  },
  { 
    code: 'ru', 
    abbr: 'RUS',
    flagIcon: <RussiaFlag />
  },
  { 
    code: 'ka', 
    abbr: 'GEO',
    flagIcon: <GeorgiaFlag />
  }
];

export const LanguageSelector: React.FC = () => {
  const { i18n } = useTranslation();
  const [isOpen, setIsOpen] = React.useState(false);
  
  const getCurrentLanguage = (): LanguageInfo => {
    return languages.find(lang => lang.code === i18n.language) || languages[0];
  };
  
  const toggleDropdown = (): void => {
    setIsOpen(!isOpen);
  };
  
  const changeLanguage = (code: string): void => {
    i18n.changeLanguage(code);
    setIsOpen(false);
  };
  
  const currentLang = getCurrentLanguage();
  
  return (
    <SelectContainer>
      <LanguageButton onClick={toggleDropdown}>
        <FlagContainer>
          {currentLang.flagIcon}
        </FlagContainer>
        {currentLang.abbr}
      </LanguageButton>
      
      <DropdownMenu $isOpen={isOpen}>
        {languages.map(lang => (
          <LanguageOption 
            key={lang.code} 
            onClick={() => changeLanguage(lang.code)}
          >
            <FlagContainer>
              {lang.flagIcon}
            </FlagContainer>
            <LanguageAbbr>{lang.abbr}</LanguageAbbr>
          </LanguageOption>
        ))}
      </DropdownMenu>
    </SelectContainer>
  );
}; 