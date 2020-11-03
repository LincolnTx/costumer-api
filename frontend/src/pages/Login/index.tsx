import React, { useState } from 'react';

import './styles.css';
import { Link, useHistory } from 'react-router-dom';
import {FaSignInAlt} from 'react-icons/fa';

import api from '../../services/api';

interface loginResponse {
    success: boolean;
    data: boolean;
    errors: loginErrors[];
}

interface loginErrors {
    code: string;
    message: string;
    paramName: string;
}


export default function Login() {
    const history = useHistory();

    const [email, setEmail] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const [errorMessage, setErrorMessage] = useState<string>('');

    async function handleLogin(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        const data = { email, password };

        try{
            const reponse = await api.post<loginResponse>('/idendity', data);

            if (reponse.data.success) {
                history.push('/home');
            } else {
                setErrorMessage(reponse.data.errors[0]?.message);
            }
        } catch(err) {
            const {errors} = JSON.parse(err.response.request.response);
            const { message } = errors[0];

            setErrorMessage(message);
            console.log(errorMessage)
        }
    }

    return (
        <div className="login-container">

            <section className="form">
                <form  onSubmit={handleLogin}>
                    <h1>Iniciar Sessão</h1>
                    {errorMessage.length > 1 ? <p>{errorMessage}</p> : ''}
                    
                    <input placeholder="E-mail"
                    type='email'
                    required={true}
                    value={email}
                    onChange={e => setEmail(e.target.value)}
                    />
                    <input placeholder="Senha" 
                    type="password"
                    required={true}
                    value={password}
                    onChange={e => setPassword(e.target.value)}
                    />
                    <button className="button" type="submit">Entrar</button>

                    <Link className="default-link" to="/register">
                        <FaSignInAlt size= {16} color="#8A05BE" />
                        Não tenho cadastro
                    </Link>
                </form>                
            </section>
        </div>
    );
}