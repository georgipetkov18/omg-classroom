import React from 'react';

export default function RegisterPage() {
    return (
        <div className='container register-form'>
            <h2 className='text-center'>Register</h2>
            <form>
                <div className='form-group'>
                    <label htmlFor='name'>Name</label>
                    <input className='form-control' id='name' type="text"></input>
                </div>

                <div className='form-group'>
                    <label htmlFor='email'>Email</label>
                    <input className='form-control' id='email' type="email"></input>
                </div>

                <div className='form-group'>
                    <label htmlFor='age'>Age</label>
                    <input className='form-control' id='age' type="number"></input>
                </div>

                <div className='form-group'>
                    <label htmlFor='password'>Password</label>
                    <input className='form-control' id='password' type="text"></input>
                </div>

                <div className='d-flex justify-content-around btn-section'>
                    <button type='submit' className='btn btn-success'>Submit</button>
                    <button type='button' className='btn btn-danger'>Clear</button>
                </div>
            </form>
        </div>
    );
}