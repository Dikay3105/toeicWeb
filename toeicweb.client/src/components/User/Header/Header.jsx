import { useState, useEffect } from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { FaPhoneAlt } from "react-icons/fa";
import "./Header.scss";

const Header = () => {
  const [isLogin, setIsLogin] = useState(false);
  const [scrollPosition, setScrollPosition] = useState(0);
  const [showUpperHeader, setShowUpperHeader] = useState(true);
  const [addDropShadow, setAddDropShadow] = useState(false);

  const handleScroll = () => {
    const currentScrollPos = window.pageYOffset;
    setScrollPosition(currentScrollPos);

    if (currentScrollPos > 300) {
      setShowUpperHeader(false);  // Ẩn upper-header
      setAddDropShadow(true);     // Thêm hiệu ứng đổ bóng
    } else {
      setShowUpperHeader(true);   // Hiển thị lại upper-header
      setAddDropShadow(false);    // Bỏ hiệu ứng đổ bóng
    }
  };

  useEffect(() => {
    window.addEventListener("scroll", handleScroll);
    return () => {
      window.removeEventListener("scroll", handleScroll);
    };
  }, []);

  return (
    <div className='header-container'>
      {showUpperHeader && (
        <div className='upper-header d-flex justify-content-evenly'>
          <div className='phone-number'><FaPhoneAlt /> 0123456789</div>
          <div className='header-banner'>Thi toeic 990đ quá dễ</div>
          <div className='login-option'>
            {isLogin ? (
              <NavDropdown title="Dropdown" id="basic-nav-dropdown">
                <NavDropdown.Item href="#action/3.1">Action</NavDropdown.Item>
                <NavDropdown.Item href="#action/3.2">Another action</NavDropdown.Item>
                <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
                <NavDropdown.Divider />
                <NavDropdown.Item href="#action/3.4">Separated link</NavDropdown.Item>
              </NavDropdown>
            ) : (
              <div className='auth-container d-flex gap-3'>
                <button className='btn btn-primary'>Login</button>
                <button className='btn btn-primary'>Sign up</button>
              </div>
            )}
          </div>
        </div>
      )}

      <div className={`main-header ${addDropShadow ? 'shadow' : ''}`}>
        <Navbar expand="lg" className="bg-body-tertiary">
          <Container>
            <Navbar.Brand href="#home">React-Bootstrap</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
              <Nav className="me-auto">
                <Nav.Link href="#home">Home</Nav.Link>
                <Nav.Link href="#link">Link</Nav.Link>
                <NavDropdown title="Dropdown" id="basic-nav-dropdown">
                  <NavDropdown.Item href="#action/3.1">Action</NavDropdown.Item>
                  <NavDropdown.Item href="#action/3.2">Another action</NavDropdown.Item>
                  <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
                  <NavDropdown.Divider />
                  <NavDropdown.Item href="#action/3.4">Separated link</NavDropdown.Item>
                </NavDropdown>
              </Nav>
            </Navbar.Collapse>
          </Container>
        </Navbar>
      </div>
    </div>
  );
}

export default Header;
