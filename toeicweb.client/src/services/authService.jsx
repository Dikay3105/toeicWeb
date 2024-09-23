import axios from 'axios'
const postLogin = (Username, PasswordHash) => {
    return axios.post('https://localhost:7233/api/Account/Login', { Username, PasswordHash });
}

const postLogOut = (email, refresh_token) => {
    return axios.post('api/v1/logout', { email, refresh_token, delay: 1000 });
}

const postRegister = (email, username, password) => {
    const form = new FormData();
    form.append('username', username);
    form.append('email', email);
    form.append('password', password);
    return axios.post('api/v1/register', form);
}

export {
    postLogin,
    postRegister,
    postLogOut
};
