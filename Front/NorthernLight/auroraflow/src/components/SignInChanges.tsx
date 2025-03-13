// Changes for SignIn.tsx:

// 1. Add the ForgotPasswordLink component:
const ForgotPasswordLink = styled.a`
  color: ${({ theme }) => theme.primary};
  font-size: 0.75rem;
  text-decoration: none;
  display: block;
  text-align: right;
  margin-top: 0.5rem;
  
  &:hover {
    text-decoration: underline;
  }
`;

// 2. Add margin-top: -5vh to MainContent:
const MainContent = styled.main`
  flex: 1;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 2rem;
  margin-top: -5vh; /* Move the content up by 5% of viewport height */
`;

// 3. Update the password InputGroup to include the ForgotPasswordLink:
/*
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
  <ForgotPasswordLink href="#">{t('signIn.forgotPassword')}</ForgotPasswordLink>
</InputGroup>
*/

// 4. Update the FooterText to only have "Don't have an account?":
/*
<FooterText>
  <a href="#">{t('signIn.dontHaveAccount')}</a>
</FooterText>
*/ 