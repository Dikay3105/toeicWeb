import React from 'react';
import Slider from 'react-slick';
import 'slick-carousel/slick/slick.css';
import 'slick-carousel/slick/slick-theme.css';
import "./Homepage.scss";
import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';

const Homepage = () => {
    const settings = {
        dots: true,
        infinite: true,
        speed: 500,
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true, // Thêm autoplay để slider tự động cuộn
        autoplaySpeed: 3000, // Thay đổi tốc độ tự động cuộn
        arrows: false, // Ẩn các nút điều hướng
    };

    return (
        <div className='homepage-container'>
            <div className='slider-container'>
                <div className='ads-slider'>
                    <div className='ads-title'>Học 1 lần là 990 điểm liền</div>
                    <button className='btn btn-warning mt-3 text-white fw-bold'>Kiểm tra ngay</button>
                </div>
                <div className='slider'>
                    <Slider {...settings}>
                        <div>
                            <img className='img-fluid' src='https://zenlishtoeic.vn/wp-content/uploads/2024/08/zenlish-luu-tai-ve-ket-qua-bai-thi-1178-x-615-px.jpg' alt='Slide 1' />
                        </div>
                        <div>
                            <img className='img-fluid' src='https://zenlishtoeic.vn/wp-content/uploads/2024/08/zenlish-luu-tai-ve-ket-qua-bai-thi-1178-x-615-px.jpg' alt='Slide 2' />
                        </div>
                        <div>
                            <img className='img-fluid' src='https://zenlishtoeic.vn/wp-content/uploads/2024/08/zenlish-luu-tai-ve-ket-qua-bai-thi-1178-x-615-px.jpg' alt='Slide 3' />
                        </div>
                        <div>
                            <img className='img-fluid' src='https://zenlishtoeic.vn/wp-content/uploads/2024/07/zenlish-chot.jpg' alt='Slide 4' />
                        </div>
                        <div>
                            <img className='img-fluid' src='https://zenlishtoeic.vn/wp-content/uploads/2024/08/zenlish-luu-tai-ve-ket-qua-bai-thi-1178-x-615-px.jpg' alt='Slide 5' />
                        </div>
                        <div>
                            <img className='img-fluid' src='https://zenlishtoeic.vn/wp-content/uploads/2024/08/zenlish-luu-tai-ve-ket-qua-bai-thi-1178-x-615-px.jpg' alt='Slide 6' />
                        </div>
                    </Slider>
                </div>
            </div>

            <div className='new-test-container'>
                <Card style={{ width: '18rem' }}>
                    <Card.Body>
                        <Card.Title>Card Title</Card.Title>
                        <Card.Text>
                            Some quick example text to build on the card title and make up the
                            bulk of the card's content.
                        </Card.Text>
                        <Button variant="primary">Go somewhere</Button>
                    </Card.Body>
                </Card>
                <Card style={{ width: '18rem' }}>
                    <Card.Body>
                        <Card.Title>Card Title</Card.Title>
                        <Card.Text>
                            Some quick example text to build on the card title and make up the
                            bulk of the card's content.
                        </Card.Text>
                        <Button variant="primary">Go somewhere</Button>
                    </Card.Body>
                </Card>
                <Card style={{ width: '18rem' }}>
                    <Card.Body>
                        <Card.Title>Card Title</Card.Title>
                        <Card.Text>
                            Some quick example text to build on the card title and make up the
                            bulk of the card's content.
                        </Card.Text>
                        <Button variant="primary">Go somewhere</Button>
                    </Card.Body>
                </Card>
                <Card style={{ width: '18rem' }}>
                    <Card.Body>
                        <Card.Title>Card Title</Card.Title>
                        <Card.Text>
                            Some quick example text to build on the card title and make up the
                            bulk of the card's content.
                        </Card.Text>
                        <Button variant="primary">Go somewhere</Button>
                    </Card.Body>
                </Card>
                <Card style={{ width: '18rem' }}>
                    <Card.Body>
                        <Card.Title>Card Title</Card.Title>
                        <Card.Text>
                            Some quick example text to build on the card title and make up the
                            bulk of the card's content.
                        </Card.Text>
                        <Button variant="primary">Go somewhere</Button>
                    </Card.Body>
                </Card>
                <Card style={{ width: '18rem' }}>
                    <Card.Body>
                        <Card.Title>Card Title</Card.Title>
                        <Card.Text>
                            Some quick example text to build on the card title and make up the
                            bulk of the card's content.
                        </Card.Text>
                        <Button variant="primary">Go somewhere</Button>
                    </Card.Body>
                </Card>
            </div>
        </div>
    );
};

export default Homepage;
