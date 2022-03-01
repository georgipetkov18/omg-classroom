import React, { useRef } from 'react';

const RegisterPage = (props) => {
    const nameRef = useRef();
    const emailRef = useRef();
    const ageRef = useRef();
    const passwordRef = useRef();

    const submitHandler = (event) => {
        event.preventDefault();
        const user = {
            name: nameRef.current.value,
            email: emailRef.current.value,
            age: ageRef.current.value,
            password: passwordRef.current.value,
        };
        props.onSubmit(user);
    };

    return (
        <div className='container register-form'>
            <h2 className='text-center'>Register</h2>
            <form onSubmit={submitHandler}>
                <div className='form-group'>
                    <label htmlFor='name'>Name</label>
                    <input className='form-control' id='name' type="text" ref={nameRef}></input>
                </div>

                <div className='form-group'>
                    <label htmlFor='email'>Email</label>
                    <input className='form-control' id='email' type="email" ref={emailRef}></input>
                </div>

                <div className='form-group'>
                    <label htmlFor='age'>Age</label>
                    <input className='form-control' id='age' type="number" ref={ageRef}></input>
                </div>

                <div className='form-group'>
                    <label htmlFor='password'>Password</label>
                    <input className='form-control' id='password' type="password" ref={passwordRef}></input>
                </div>

                <div className='d-flex justify-content-around btn-section'>
                    <button type='submit' className='btn btn-success'>Submit</button>
                    <button type='button' className='btn btn-danger'>Clear</button>
                </div>
            </form>
        </div>
    );
}

export default RegisterPage;