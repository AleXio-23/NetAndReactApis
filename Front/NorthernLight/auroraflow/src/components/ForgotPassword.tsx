'use client';

import React, { FormEvent, useState } from 'react';
import styled from 'styled-components';
import { useTranslation } from 'react-i18next';
import { ThemeToggle } from './ThemeToggle';
import { LanguageSelector } from './LanguageSelector';
import Link from 'next/link';

const PageContainer = styled.div`
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  background-color: transparent;
  position: relative;
  z-index: 1;
  color: ${({ theme }) => theme.text};
  transition: background-color 0.2s ease, color 0.2s ease;
  font-family: var(--font-inter), -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
`;

const Header = styled.header`
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem 2rem;
  position: relative;
  z-index: 10;
`;

const Logo = styled.h1`
  color: ${({ theme }) => theme.primary};
  font-size: 1.35rem;
  font-weight: 600;
  margin: 0;
  background: linear-gradient(to right, ${({ theme }) => theme.primary}, ${({ theme }) => theme.secondary});
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
`;

const HeaderControls = styled.div`
  display: flex;
  align-items: center;
  gap: 1rem;
  position: relative;
  z-index: 11;
  pointer-events: auto;
`;

const MainContent = styled.main`
  flex: 1;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 2rem;
  margin-top: -5vh;
`;

const RecoveryCard = styled.div`
  background-color: ${({ theme }) => theme.cardBackground};
  border-radius: 0.75rem;
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.12), 0 0 40px rgba(0, 0, 0, 0.08);
  padding: 2.5rem;
  width: 100%;
  max-width: 28rem;
  transition: background-color 0.2s ease, box-shadow 0.3s ease;
  position: relative;
  z-index: 2;
  backdrop-filter: blur(5px);
  
  &:hover {
    box-shadow: 0 12px 30px rgba(0, 0, 0, 0.15), 0 0 45px rgba(0, 0, 0, 0.1);
  }
`;

const Title = styled.h2`
  color: ${({ theme }) => theme.text};
  font-size: 1.35rem;
  font-weight: 500;
  margin-bottom: 1rem;
  text-align: center;
`;

const Subtitle = styled.p`
  color: ${({ theme }) => theme.textSecondary};
  font-size: 0.9rem;
  text-align: center;
  margin-bottom: 1.5rem;
`;

const Form = styled.form`
  display: flex;
  flex-direction: column;
  gap: 1.25rem;
`;

const FormSection = styled.div`
  margin-bottom: 1.5rem;
`;

const InputGroup = styled.div`
  display: flex;
  flex-direction: column;
  margin-bottom: 1.5rem;
`;

const Label = styled.label`
  color: ${({ theme }) => theme.text};
  font-size: 0.79rem;
  font-weight: 400;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  min-height: 1.2em;
`;

const Input = styled.input`
  background-color: ${({ theme }) => theme.inputBackground};
  border: 1px solid ${({ theme }) => theme.inputBorder};
  border-radius: 0.375rem;
  color: ${({ theme }) => theme.text};
  font-size: 0.9rem;
  font-weight: 400;
  padding: 0.75rem 1rem;
  width: 100%;
  transition: border-color 0.2s ease, background-color 0.2s ease;
  
  &:focus {
    border-color: ${({ theme }) => theme.primary};
    outline: none;
  }
  
  &::placeholder {
    color: #9ca3af;
  }
`;

const SubmitButton = styled.button`
  width: 100%;
  background: linear-gradient(to right, ${({ theme }) => theme.primary}, ${({ theme }) => theme.secondary});
  border: none;
  border-radius: 0.375rem;
  color: ${({ theme }) => theme.buttonText};
  cursor: pointer;
  font-size: 0.9rem;
  font-weight: 500;
  padding: 0.75rem;
  transition: opacity 0.2s ease;
  
  &:hover {
    opacity: 0.9;
  }
`;

const BackLinkContainer = styled.div`
  margin-top: 1.5rem;
  text-align: center;
`;

const BackLink = styled(Link)`
  color: ${({ theme }) => theme.primary};
  font-size: 0.85rem;
  text-decoration: none;
  display: inline-flex;
  align-items: center;
  gap: 0.5rem;
  
  &:hover {
    text-decoration: underline;
  }
`;

const StatusMessage = styled.div<{ isError?: boolean }>`
  margin-top: 1rem;
  padding: 0.75rem;
  border-radius: 0.375rem;
  font-size: 0.85rem;
  text-align: center;
  background-color: ${({ theme, isError }) => 
    isError ? 'rgba(239, 68, 68, 0.1)' : 'rgba(34, 197, 94, 0.1)'};
  color: ${({ theme, isError }) => 
    isError ? theme.error || '#ef4444' : theme.success || '#22c55e'};
`;

const ForgotPassword: React.FC = () => {
  const [email, setEmail] = useState('');
  const [status, setStatus] = useState<{ message: string; isError: boolean } | null>(null);
  const { t } = useTranslation();
  
  const handleSubmit = (e: FormEvent<HTMLFormElement>): void => {
    e.preventDefault();
    
    // Here you would typically call your API to send a recovery email
    // For now, we'll just show a success message
    setStatus({
      message: t('forgotPassword.emailSent', { email }),
      isError: false
    });
    
    // Reset form
    setEmail('');
  };
  
  return (
    <PageContainer>
      <Header>
        <Logo>AuroraFlow</Logo>
        <HeaderControls>
          <ThemeToggle />
          <LanguageSelector />
        </HeaderControls>
      </Header>
      
      <MainContent>
        <RecoveryCard>
          <Title>{t('forgotPassword.title', 'Reset Password')}</Title>
          <Subtitle>
            {t('forgotPassword.subtitle', 'Enter your email address and we\'ll send you instructions to reset your password.')}
          </Subtitle>
          
          <Form onSubmit={handleSubmit}>
            <FormSection>
              <InputGroup>
                <Label htmlFor="email">{t('forgotPassword.emailLabel', 'Email Address')}</Label>
                <Input
                  id="email"
                  type="email"
                  placeholder={t('forgotPassword.emailPlaceholder', 'your-email@example.com')}
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
                  required
                />
              </InputGroup>
              
              <SubmitButton type="submit">
                {t('forgotPassword.submit', 'Send Recovery Instructions')}
              </SubmitButton>
            </FormSection>
          </Form>
          
          {status && (
            <StatusMessage isError={status.isError}>
              {status.message}
            </StatusMessage>
          )}
          
          <BackLinkContainer>
            <BackLink href="/signin">
              ← {t('forgotPassword.backToSignIn', 'Back to Sign In')}
            </BackLink>
          </BackLinkContainer>
        </RecoveryCard>
      </MainContent>
    </PageContainer>
  );
};

export default ForgotPassword; 