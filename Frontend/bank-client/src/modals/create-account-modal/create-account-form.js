import React from 'react'
import './create-account-form.scss'

function CreateAccountForm() {
	return (
		<>
			<h5 className='create-account-title'>Account type</h5>
			<select className='create-account-select'>
				<option value={'Standard'}>Standard</option>
				<option value={'Business'}>Business</option>
				<option value={'Saving'}>Saving</option>
				<option value={'Investment'}>Investment</option>
			</select>
			<h5 className='create-account-title'>Account name</h5>
			<input placeholder='name'></input>
		</>
	)
}

export default CreateAccountForm