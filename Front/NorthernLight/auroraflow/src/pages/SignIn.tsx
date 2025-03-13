import React, { useState, FormEvent } from 'react';
import styled from 'styled-components';
import { useTranslation } from 'react-i18next';
import { ThemeToggle } from '../components/ThemeToggle';
import { LanguageSelector } from '../components/LanguageSelector';

const PageContainer = styled.div`
  display: flex;
  flex-direction: column;
  min-height: 100vh;
  background-color: ${({ theme }) => theme.background};
  color: ${({ theme }) => theme.text};
  transition: background-color 0.2s ease, color 0.2s ease;
`;

const Header = styled.header`
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem 2rem;
`;

const Logo = styled.h1`
  color: ${({ theme }) => theme.primary};
  font-size: 1.5rem;
  font-weight: bold;
  margin: 0;
  background: linear-gradient(to right, ${({ theme }) => theme.primary}, ${({ theme }) => theme.secondary});
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
`;

const HeaderControls = styled.div`
  display: flex;
  align-items: center;
`;

const MainContent = styled.main`
  flex: 1;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 2rem;
`;

const SignInCard = styled.div`
  background-color: ${({ theme }) => theme.cardBackground};
  border-radius: 0.75rem;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  padding: 2.5rem;
  width: 100%;
  max-width: 28rem;
  transition: background-color 0.2s ease;
`;

const Title = styled.h2`
  color: ${({ theme }) => theme.text};
  font-size: 1.5rem;
  font-weight: 600;
  margin-bottom: 1.5rem;
  text-align: center;
`;

const Form = styled.form`
  display: flex;
  flex-direction: column;
  gap: 1.25rem;
`;

const InputGroup = styled.div`
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
`;

const Label = styled.label`
  color: ${({ theme }) => theme.text};
  font-size: 0.875rem;
  font-weight: 500;
`;

const InputWrapper = styled.div`
  position: relative;
`;

const Input = styled.input`
  background-color: ${({ theme }) => theme.inputBackground};
  border: 1px solid ${({ theme }) => theme.inputBorder};
  border-radius: 0.375rem;
  color: ${({ theme }) => theme.text};
  font-size: 1rem;
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

const PasswordButton = styled.button`
  background: transparent;
  border: none;
  color: ${({ theme }) => theme.text};
  cursor: pointer;
  position: absolute;
  right: 1rem;
  top: 50%;
  transform: translateY(-50%);
`;

const SignInButton = styled.button`
  background: linear-gradient(to right, ${({ theme }) => theme.primary}, ${({ theme }) => theme.secondary});
  border: none;
  border-radius: 0.375rem;
  color: ${({ theme }) => theme.buttonText};
  cursor: pointer;
  font-size: 1rem;
  font-weight: 500;
  margin-top: 0.5rem;
  padding: 0.75rem;
  transition: opacity 0.2s ease;
  
  &:hover {
    opacity: 0.9;
  }
`;

const Divider = styled.div`
  display: flex;
  align-items: center;
  margin: 1.5rem 0;
  
  &::before, &::after {
    content: '';
    flex: 1;
    border-bottom: 1px solid ${({ theme }) => theme.inputBorder};
  }
  
  span {
    color: ${({ theme }) => theme.text};
    font-size: 0.875rem;
    padding: 0 1rem;
  }
`;

const GoogleButton = styled.button`
  background-color: white;
  border: 1px solid #d1d5db;
  border-radius: 0.375rem;
  color: #4b5563;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1rem;
  font-weight: 500;
  gap: 0.75rem;
  padding: 0.75rem;
  transition: background-color 0.2s ease;
  
  &:hover {
    background-color: #f9fafb;
  }
  
  svg {
    height: 1.5rem;
    width: 1.5rem;
  }
`;

const FooterText = styled.p`
  color: ${({ theme }) => theme.text};
  font-size: 0.875rem;
  margin-top: 1.5rem;
  text-align: center;
  
  a {
    color: ${({ theme }) => theme.primary};
    font-weight: 500;
    text-decoration: none;
    
    &:hover {
      text-decoration: underline;
    }
  }
`;

const SignIn: React.FC = () => {
  const [showPassword, setShowPassword] = useState<boolean>(false);
  const { t } = useTranslation();
  
  const togglePasswordVisibility = (): void => {
    setShowPassword(!showPassword);
  };
  
  const handleSubmit = (e: FormEvent<HTMLFormElement>): void => {
    e.preventDefault();
    // Add sign-in logic here
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
        <SignInCard>
          <Title>{t('signIn.title')}</Title>
          
          <Form onSubmit={handleSubmit}>
            <InputGroup>
              <Label htmlFor="email">{t('signIn.email')}</Label>
              <Input
                id="email"
                type="email"
                placeholder="example@email.com"
                required
              />
            </InputGroup>
            
            <InputGroup>
              <Label htmlFor="password">{t('signIn.password')}</Label>
              <InputWrapper>
                <Input
                  id="password"
                  type={showPassword ? "text" : "password"}
                  placeholder="••••••••"
                  required
                />
                <PasswordButton
                  type="button"
                  onClick={togglePasswordVisibility}
                  aria-label={showPassword ? "Hide password" : "Show password"}
                >
                  {showPassword ? "👁️" : "👁️‍🗨️"}
                </PasswordButton>
              </InputWrapper>
            </InputGroup>
            
            <SignInButton type="submit">
              {t('signIn.signInButton')}
            </SignInButton>
          </Form>
          
          <Divider>
            <span>OR</span>
          </Divider>
          
          <GoogleButton type="button">
            <svg viewBox="0 0 24 24">
              <path 
                fill="#4285F4" 
                d="M22.56 12.25c0-.78-.07-1.53-.2-2.25H12v4.26h5.92c-.26 1.37-1.04 2.53-2.21 3.31v2.77h3.57c2.08-1.92 3.28-4.74 3.28-8.09z" 
              />
              <path 
                fill="#34A853" 
                d="M12 23c2.97 0 5.46-.98 7.28-2.66l-3.57-2.77c-.98.66-2.23 1.06-3.71 1.06-2.86 0-5.29-1.93-6.16-4.53H2.18v2.84C3.99 20.53 7.7 23 12 23z" 
              />
              <path 
                fill="#FBBC05" 
                d="M5.84 14.09c-.22-.66-.35-1.36-.35-2.09s.13-1.43.35-2.09V7.07H2.18C1.43 8.55 1 10.22 1 12s.43 3.45 1.18 4.93l2.85-2.22.81-.62z" 
              />
              <path 
                fill="#EA4335" 
                d="M12 5.38c1.62 0 3.06.56 4.21 1.64l3.15-3.15C17.45 2.09 14.97 1 12 1 7.7 1 3.99 3.47 2.18 7.07l3.66 2.84c.87-2.6 3.3-4.53 6.16-4.53z" 
              />
            </svg>
            {t('signIn.signInWithGoogle')}
          </GoogleButton>
          
          <FooterText>
            <a href="#">{t('signIn.forgotPassword')}</a> • <a href="#">{t('signIn.dontHaveAccount')}</a>
          </FooterText>
        </SignInCard>
      </MainContent>
    </PageContainer>
  );
};

export default SignIn; 