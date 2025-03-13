'use client';

import React, { useContext } from 'react';
import styled from 'styled-components';
import { ThemeContext } from '../theme/ThemeProvider';
import { useTranslation } from 'react-i18next';

const ToggleButton = styled.button`
  background: transparent;
  border: none;
  color: ${({ theme }) => theme.text};
  cursor: pointer;
  font-size: 1.25rem;
  padding: 0.5rem;
  display: flex;
  align-items: center;
  justify-content: center;
  transition: color 0.2s ease;
  
  &:hover {
    color: ${({ theme }) => theme.primary};
  }
`;

export const ThemeToggle: React.FC = () => {
  const { theme, toggleTheme } = useContext(ThemeContext);
  const { t } = useTranslation();
  
  return (
    <ToggleButton onClick={toggleTheme} aria-label={t('header.darkMode')}>
      {theme.isDark ? '☀️' : '🌙'}
    </ToggleButton>
  );
}; 