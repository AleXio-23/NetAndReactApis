'use client';

import React from 'react';
import styled from 'styled-components';
import Link from 'next/link';
import { usePathname } from 'next/navigation';
import { useTranslation } from 'react-i18next';
import { ThemeToggle } from '@/components/ThemeToggle';
import { LanguageSelector } from '@/components/LanguageSelector';

const LayoutContainer = styled.div`
  display: flex;
  min-height: 100vh;
  background-color: ${({ theme }) => theme.backgroundPrimary};
  color: ${({ theme }) => theme.text};
  position: relative;
  
  &::before {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: ${({ theme }) => theme.isDark 
      ? 'linear-gradient(135deg, rgba(17,24,39,0.95) 0%, rgba(31,41,55,0.9) 100%)'
      : 'linear-gradient(135deg, rgba(249,250,251,0.95) 0%, rgba(243,244,246,0.9) 100%)'
    };
    z-index: -1;
  }
`;

const Sidebar = styled.aside`
  width: 240px;
  flex-shrink: 0;
  background-color: ${({ theme }) => theme.cardBackground};
  border-right: 1px solid ${({ theme }) => theme.inputBorder};
  display: flex;
  flex-direction: column;
  transition: width 0.3s ease;
  z-index: 10;
`;

const SidebarHeader = styled.div`
  padding: 1rem;
  border-bottom: 1px solid ${({ theme }) => theme.inputBorder};
`;

const Logo = styled.h1`
  color: ${({ theme }) => theme.primary};
  font-size: 1.5rem;
  font-weight: 600;
  margin: 0;
  background: linear-gradient(to right, ${({ theme }) => theme.primary}, ${({ theme }) => theme.secondary});
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
`;

const WorkspaceSelector = styled.div`
  display: flex;
  align-items: center;
  padding: 0.75rem 1rem;
  cursor: pointer;
  margin-top: 0.5rem;
  border-radius: 4px;
  
  &:hover {
    background-color: ${({ theme }) => theme.backgroundSecondary};
  }
`;

const WorkspaceIcon = styled.div`
  width: 24px;
  height: 24px;
  border-radius: 4px;
  background-color: ${({ theme }) => theme.primary};
  display: flex;
  align-items: center;
  justify-content: center;
  margin-right: 10px;
  color: white;
  font-weight: bold;
`;

const WorkspaceName = styled.span`
  font-size: 0.9rem;
  font-weight: 500;
  flex: 1;
`;

const Navigation = styled.nav`
  flex: 1;
  padding: 1rem 0;
  overflow-y: auto;
`;

interface NavItemProps {
  isActive: boolean;
}

const NavItem = styled(Link)<NavItemProps>`
  display: flex;
  align-items: center;
  padding: 0.75rem 1rem;
  color: ${({ theme, isActive }) => (isActive ? theme.primary : theme.text)};
  text-decoration: none;
  font-size: 0.9rem;
  
  &:hover {
    background-color: ${({ theme }) => theme.backgroundSecondary};
  }
  
  ${({ isActive, theme }) => isActive && `
    background-color: ${theme.backgroundSecondary};
    font-weight: 500;
  `}
`;

const NavIcon = styled.span`
  margin-right: 10px;
  font-size: 1.1rem;
  width: 24px;
  display: flex;
  align-items: center;
  justify-content: center;
`;

const MainContent = styled.div`
  flex: 1;
  display: flex;
  flex-direction: column;
  overflow: hidden;
`;

const Header = styled.header`
  height: 60px;
  background-color: ${({ theme }) => theme.cardBackground};
  border-bottom: 1px solid ${({ theme }) => theme.inputBorder};
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 1.5rem;
  z-index: 5;
`;

const SearchBar = styled.div`
  flex: 1;
  max-width: 500px;
  margin: 0 2rem;
`;

const SearchInput = styled.input`
  background-color: ${({ theme }) => theme.inputBackground};
  border: 1px solid ${({ theme }) => theme.inputBorder};
  border-radius: 4px;
  color: ${({ theme }) => theme.text};
  font-size: 0.9rem;
  padding: 0.5rem 1rem;
  width: 100%;
  transition: border-color 0.2s ease;
  
  &:focus {
    border-color: ${({ theme }) => theme.primary};
    outline: none;
  }
`;

const HeaderControls = styled.div`
  display: flex;
  align-items: center;
  gap: 1rem;
`;

const UserAvatar = styled.div`
  width: 36px;
  height: 36px;
  border-radius: 50%;
  background-color: ${({ theme }) => theme.primary};
  color: white;
  display: flex;
  align-items: center;
  justify-content: center;
  font-weight: bold;
  cursor: pointer;
`;

const Content = styled.main`
  flex: 1;
  padding: 2rem;
  overflow-y: auto;
`;

interface DashboardLayoutProps {
  children: React.ReactNode;
}

const DashboardLayout: React.FC<DashboardLayoutProps> = ({ children }) => {
  const pathname = usePathname();
  const { t, i18n } = useTranslation();
  const [, forceUpdate] = React.useState({});
  
  // Update component when language changes
  React.useEffect(() => {
    // Force re-render when language changes to update all translations
    const handleLanguageChanged = () => {
      forceUpdate({});
    };
    
    i18n.on('languageChanged', handleLanguageChanged);
    
    return () => {
      i18n.off('languageChanged', handleLanguageChanged);
    };
  }, [i18n]);
  
  const navItems = [
    { label: t('dashboard.home'), icon: '🏠', href: '/dashboard' },
    { label: t('dashboard.projects'), icon: '📂', href: '/dashboard/projects' },
    { label: t('dashboard.tasks'), icon: '✓', href: '/dashboard/tasks' },
    { label: t('dashboard.calendar'), icon: '📅', href: '/dashboard/calendar' },
    { label: t('dashboard.analytics'), icon: '📊', href: '/dashboard/analytics' },
    { label: t('dashboard.settings'), icon: '⚙️', href: '/dashboard/settings' },
  ];
  
  return (
    <LayoutContainer>
      <Sidebar>
        <SidebarHeader>
          <Logo>AuroraFlow</Logo>
          <WorkspaceSelector>
            <WorkspaceIcon>A</WorkspaceIcon>
            <WorkspaceName>{t('dashboard.workspace')}</WorkspaceName>
          </WorkspaceSelector>
        </SidebarHeader>
        <Navigation>
          {navItems.map(item => (
            <NavItem 
              key={item.href} 
              href={item.href} 
              isActive={pathname === item.href}
            >
              <NavIcon>{item.icon}</NavIcon>
              {item.label}
            </NavItem>
          ))}
        </Navigation>
      </Sidebar>
      <MainContent>
        <Header>
          <SearchBar>
            <SearchInput 
              type="text" 
              placeholder={t('dashboard.search')} 
            />
          </SearchBar>
          <HeaderControls>
            <ThemeToggle />
            <LanguageSelector />
            <UserAvatar>A</UserAvatar>
          </HeaderControls>
        </Header>
        <Content>
          {children}
        </Content>
      </MainContent>
    </LayoutContainer>
  );
};

export default DashboardLayout; 