'use client';

import React, { useState, FormEvent, ChangeEvent } from 'react';
import styled from 'styled-components';
import { useTranslation } from 'react-i18next';
import { ThemeToggle } from './ThemeToggle';
import { LanguageSelector } from './LanguageSelector';
import Link from 'next/link';
import Image from 'next/image';

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
  padding: 1.5rem;
  margin-top: -5vh;
`;

const SignUpCard = styled.div`
  background-color: ${({ theme }) => theme.cardBackground};
  border-radius: 0.75rem;
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.12), 0 0 40px rgba(0, 0, 0, 0.08);
  padding: 2rem;
  width: 100%;
  max-width: 46rem;
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
  margin-bottom: 1.25rem;
  text-align: center;
`;

const Form = styled.form`
  display: flex;
  flex-direction: column;
  gap: 1rem;
`;

const InputGroup = styled.div`
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
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

const InputWrapper = styled.div`
  position: relative;
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
  
  /* Improve date input styling */
  &[type="date"] {
    &::-webkit-calendar-picker-indicator {
      cursor: pointer;
      opacity: 0.6;
      transition: opacity 0.2s ease;
      
      &:hover {
        opacity: 1;
      }
    }
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
    font-size: 0.79rem;
    font-weight: 400;
    padding: 0 1rem;
  }
`;

interface ButtonsGridProps {
  isGeorgian?: boolean;
}

const ButtonsGrid = styled.div<ButtonsGridProps>`
  display: flex;
  gap: 1rem;
  width: 100%;
  margin-top: 1.5rem;
  
  @media (max-width: 500px) {
    flex-direction: ${({ isGeorgian }) => isGeorgian ? 'column' : 'row'};
  }
`;

const SignUpButton = styled.button`
  flex: 1;
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

const GoogleButton = styled.button`
  flex: 1;
  background-color: white;
  border: 1px solid #d1d5db;
  border-radius: 0.375rem;
  color: #4b5563;
  cursor: pointer;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 0.9rem;
  font-weight: 500;
  gap: 0.75rem;
  padding: 0.75rem;
  transition: background-color 0.2s ease;
  
  &:hover {
    background-color: #f9fafb;
  }
  
  svg {
    height: 1.35rem;
    width: 1.35rem;
  }
`;

const FooterText = styled.div`
  margin-top: 1rem;
  text-align: center;
  color: ${({ theme }) => theme.textSecondary};
  font-size: 0.65rem;
`;

const SignInLink = styled(Link)`
  color: ${({ theme }) => theme.primary};
  font-weight: 500;
  text-decoration: none;
  
  &:hover {
    text-decoration: underline;
  }
`;

const InfoDivider = styled(Divider)`
  margin: 1.25rem 0;
  
  span {
    font-weight: 500;
    color: ${({ theme }) => theme.text};
  }
`;

const ThreeColumnGrid = styled.div`
  display: grid;
  grid-template-columns: repeat(3, 1fr);
  gap: 1rem;
  width: 100%;
  margin-bottom: 1rem;
  
  @media (max-width: 992px) {
    grid-template-columns: repeat(2, 1fr);
  }
  
  @media (max-width: 768px) {
    grid-template-columns: 1fr;
  }
`;

const TwoColumnGrid = styled.div`
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 1rem;
  width: 100%;
  margin-bottom: 1rem;
  
  @media (max-width: 768px) {
    grid-template-columns: 1fr;
  }
`;

const FormSection = styled.div`
  display: flex;
  flex-direction: column;
  gap: 1rem;
`;

const AvatarWithDetailsGrid = styled.div`
  display: grid;
  grid-template-columns: auto 1fr;
  gap: 1.25rem;
  margin-bottom: 0.75rem;
  align-items: start;
  
  @media (max-width: 500px) {
    grid-template-columns: 1fr;
    justify-items: center;
  }
`;

const AvatarUploadContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
`;

const AvatarPlaceholder = styled.div`
  width: 90px;
  height: 90px;
  border-radius: 50%;
  background-color: ${({ theme }) => theme.backgroundSecondary};
  display: flex;
  justify-content: center;
  align-items: center;
  font-size: 2rem;
  color: ${({ theme }) => theme.textSecondary};
  overflow: hidden;
  position: relative;
  border: none;
`;

const AvatarPreview = styled.img`
  width: 100%;
  height: 100%;
  border-radius: 50%;
  object-fit: cover;
`;

const FileInputLabel = styled.label`
  color: ${({ theme }) => theme.primary};
  font-size: 0.85rem;
  cursor: pointer;
  display: inline-flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  max-width: 120px;
  padding: 6px 12px;
  border-radius: 4px;
  background-color: transparent;
  border: none;
  text-decoration: underline;
  transition: all 0.2s ease;
  
  &:hover {
    color: ${({ theme }) => theme.secondary};
  }
`;

const HiddenFileInput = styled.input`
  display: none;
`;

const AvatarSection = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  margin-top: 10px;
  width: 100%;
  min-width: 120px;
`;

const AvatarContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 100%;
  position: relative;
`;

const CircleBorder = styled.div`
  width: 110px;
  height: 110px;
  border-radius: 50%;
  border: 2px dashed ${({ theme }) => theme.inputBorder};
  display: flex;
  justify-content: center;
  align-items: center;
  margin-bottom: 1rem;
`;

// Add this new component for the picture+name layout
const ProfileNameGrid = styled.div`
  display: grid;
  grid-template-columns: auto 1fr;
  gap: 1.5rem;
  width: 100%;
  margin-bottom: 1.5rem;
  
  @media (max-width: 768px) {
    grid-template-columns: 1fr;
    justify-items: center;
  }
`;

const NameFieldsContainer = styled.div`
  display: flex;
  flex-direction: column;
  gap: 1rem;
  justify-content: center;
  height: 100%;
  
  @media (max-width: 768px) {
    width: 100%;
    max-width: 400px;
  }
`;

// Add a component for side-by-side fields
const FieldRow = styled.div`
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 1rem;
  width: 100%;
  
  @media (max-width: 500px) {
    grid-template-columns: 1fr;
  }
`;

const SignUp: React.FC = () => {
  const [showPassword, setShowPassword] = useState<boolean>(false);
  const [showConfirmPassword, setShowConfirmPassword] = useState<boolean>(false);
  const [avatarPreview, setAvatarPreview] = useState<string | null>(null);
  const { t, i18n } = useTranslation();
  const isGeorgian = i18n.language === 'ka';
  
  // Get today's date in YYYY-MM-DD format for max date attribute
  const today = new Date().toISOString().split('T')[0];
  
  const togglePasswordVisibility = (): void => {
    setShowPassword(!showPassword);
  };
  
  const toggleConfirmPasswordVisibility = (): void => {
    setShowConfirmPassword(!showConfirmPassword);
  };
  
  const handleAvatarChange = (e: ChangeEvent<HTMLInputElement>): void => {
    if (e.target.files && e.target.files[0]) {
      const file = e.target.files[0];
      const reader = new FileReader();
      
      reader.onload = (event) => {
        if (event.target && typeof event.target.result === 'string') {
          setAvatarPreview(event.target.result);
        }
      };
      
      reader.readAsDataURL(file);
    }
  };
  
  const handleSubmit = (e: FormEvent<HTMLFormElement>): void => {
    e.preventDefault();
    // Add sign-up logic here
  };
  
  const handleGoogleSignUp = (): void => {
    // Add Google sign-up logic here
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
        <SignUpCard>
          <Title>{t('signUp.title')}</Title>
          
          <Divider>
            <span>{t('signUp.accountInformation')}</span>
          </Divider>
          
          <Form onSubmit={handleSubmit}>
            <FormSection>
              {isGeorgian ? (
                <TwoColumnGrid>
                  <InputGroup>
                    <Label htmlFor="emailOrUsername">{t('signUp.emailOrUsername')}</Label>
                    <Input
                      id="emailOrUsername"
                      type="text"
                      placeholder="example@email.com"
                      required
                    />
                  </InputGroup>
                  
                  <InputGroup>
                    <Label htmlFor="password">{t('signUp.password')}</Label>
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
                  
                  <InputGroup>
                    <Label htmlFor="confirmPassword">{t('signUp.confirmPassword')}</Label>
                    <InputWrapper>
                      <Input
                        id="confirmPassword"
                        type={showConfirmPassword ? "text" : "password"}
                        placeholder="••••••••"
                        required
                      />
                      <PasswordButton
                        type="button"
                        onClick={toggleConfirmPasswordVisibility}
                        aria-label={showConfirmPassword ? "Hide password" : "Show password"}
                      >
                        {showConfirmPassword ? "👁️" : "👁️‍🗨️"}
                      </PasswordButton>
                    </InputWrapper>
                  </InputGroup>
                </TwoColumnGrid>
              ) : (
                <ThreeColumnGrid>
                  <InputGroup>
                    <Label htmlFor="emailOrUsername">{t('signUp.emailOrUsername')}</Label>
                    <Input
                      id="emailOrUsername"
                      type="text"
                      placeholder="example@email.com"
                      required
                    />
                  </InputGroup>
                  
                  <InputGroup>
                    <Label htmlFor="password">{t('signUp.password')}</Label>
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
                  
                  <InputGroup>
                    <Label htmlFor="confirmPassword">{t('signUp.confirmPassword')}</Label>
                    <InputWrapper>
                      <Input
                        id="confirmPassword"
                        type={showConfirmPassword ? "text" : "password"}
                        placeholder="••••••••"
                        required
                      />
                      <PasswordButton
                        type="button"
                        onClick={toggleConfirmPasswordVisibility}
                        aria-label={showConfirmPassword ? "Hide password" : "Show password"}
                      >
                        {showConfirmPassword ? "👁️" : "👁️‍🗨️"}
                      </PasswordButton>
                    </InputWrapper>
                  </InputGroup>
                </ThreeColumnGrid>
              )}
            </FormSection>
            
            <InfoDivider>
              <span>{t('signUp.additionalInfo')}</span>
            </InfoDivider>
            
            <FormSection>
              <ProfileNameGrid>
                <InputGroup>
                  <Label htmlFor="avatar">{t('signUp.avatar')}</Label>
                  <AvatarSection>
                    <CircleBorder>
                      <AvatarPlaceholder>
                        {avatarPreview ? (
                          <AvatarPreview src={avatarPreview} alt="Avatar preview" />
                        ) : (
                          "👤"
                        )}
                      </AvatarPlaceholder>
                    </CircleBorder>
                    <FileInputLabel htmlFor="avatar">
                      {t('signUp.chooseFile')}
                    </FileInputLabel>
                    <HiddenFileInput
                      id="avatar"
                      type="file"
                      accept="image/*"
                      onChange={handleAvatarChange}
                    />
                  </AvatarSection>
                </InputGroup>
                
                <NameFieldsContainer>
                  <FieldRow>
                    <InputGroup>
                      <Label htmlFor="firstName">{t('signUp.firstName')}</Label>
                      <Input
                        id="firstName"
                        type="text"
                        placeholder={t('signUp.firstNamePlaceholder')}
                      />
                    </InputGroup>
                    
                    <InputGroup>
                      <Label htmlFor="lastName">{t('signUp.lastName')}</Label>
                      <Input
                        id="lastName"
                        type="text"
                        placeholder={t('signUp.lastNamePlaceholder')}
                      />
                    </InputGroup>
                  </FieldRow>
                  
                  <FieldRow>
                    <InputGroup>
                      <Label htmlFor="birthDate">{t('signUp.birthDate')}</Label>
                      <Input
                        id="birthDate"
                        type="date"
                        max={today}
                      />
                    </InputGroup>
                    
                    <InputGroup>
                      <Label htmlFor="personalNumber">{t('signUp.personalNumber')}</Label>
                      <Input
                        id="personalNumber"
                        type="text"
                        placeholder={t('signUp.personalNumberPlaceholder')}
                      />
                    </InputGroup>
                  </FieldRow>
                </NameFieldsContainer>
              </ProfileNameGrid>
              
              <TwoColumnGrid>
                <InputGroup>
                  <Label htmlFor="phoneNumber1">{t('signUp.phoneNumber1')}</Label>
                  <Input
                    id="phoneNumber1"
                    type="tel"
                    placeholder={isGeorgian ? "+995 5XX XXX XXX" : "+1 (555) 000-0000"}
                  />
                </InputGroup>
                
                <InputGroup>
                  <Label htmlFor="phoneNumber2">{t('signUp.phoneNumber2')}</Label>
                  <Input
                    id="phoneNumber2"
                    type="tel"
                    placeholder={isGeorgian ? "+995 5XX XXX XXX" : "+1 (555) 000-0000"}
                  />
                </InputGroup>
              </TwoColumnGrid>
            </FormSection>
            
            <ButtonsGrid isGeorgian={isGeorgian}>
              <SignUpButton type="submit">
                {t('signUp.submit')}
              </SignUpButton>
              <GoogleButton type="button" onClick={handleGoogleSignUp}>
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
                {t('signUp.signUpWithGoogle')}
              </GoogleButton>
            </ButtonsGrid>
          </Form>
          
          <FooterText>
            {t('signUp.alreadyHaveAccount')} <SignInLink href="/signin">{t('signUp.signIn')}</SignInLink>
          </FooterText>
        </SignUpCard>
      </MainContent>
    </PageContainer>
  );
};

export default SignUp; 