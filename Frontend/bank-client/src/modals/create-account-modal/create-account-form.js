import React, { useEffect, useState } from 'react'
import { useDispatch } from 'react-redux'
import { setModalData } from '../../redux/reducers/modal-reducer'
import './create-account-form.scss'

function CreateAccountForm() {
	const dispatch = useDispatch()

	const [type, setType] = useState('Standard')
	const [name, setName] = useState('')

	useEffect(() => {
		setData()
	}, [])

	useEffect(() => {
		setData()
	}, [type, name])

	const setData = () => {
		dispatch(setModalData({ type, name }))
	}

	return (
		<>
			<h5 className='create-account-title'>Account type</h5>
			<select className='create-account-select' onChange={(e) => setType(e.target.value)}>
				<option value={'Standard'}>Standard</option>
				<option value={'Business'}>Business</option>
				<option value={'Saving'}>Saving</option>
				<option value={'Investment'}>Investment</option>
			</select>
			<h5 className='create-account-title'>Account name</h5>
			<input placeholder='name' onChange={((e) => setName(e.target.value))}></input>
		</>
	)
}

export default CreateAccountForm