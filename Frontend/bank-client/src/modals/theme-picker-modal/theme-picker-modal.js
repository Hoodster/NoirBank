import React from 'react'
import { useDispatch } from 'react-redux'
import Radio from '../../components/inputs/radio/radio'
import ModalBase from '../../components/modal/modal-base'
import { close } from '../../redux/reducers/modal-reducer'
import { setApplicationTheme } from '../../redux/reducers/settings-reducer'

function ThemePickerModal() {
	const dispatch = useDispatch()
	const currentTheme = localStorage.getItem('theme')

	const primaryAction = {
		text: 'Change theme',
		action: () => {
			const newTheme = document.querySelector('input[name="themeRadioGroup"]:checked').value
			dispatch(setApplicationTheme(newTheme))
			dispatch(close())
		}
	}

	const secondaryAction = {
		text: 'Cancel',
		action: () => dispatch(close())
	}
    
	return (
		<ModalBase primaryAction={primaryAction} secondaryAction={secondaryAction} title='Set application theme' contentPosition='center'>
			<Radio id='system_opt' name='themeRadioGroup' text='Default (system)' value='system' default={currentTheme === 'system' || !currentTheme}/>
			<Radio id='dark_opt' name='themeRadioGroup' text='Dark' value='dark' default={currentTheme === 'dark'}/>
			<Radio id='light_opt' name='themeRadioGroup' text='Light' value='light' default={currentTheme === 'light'}/>
		</ModalBase>
	)
}

export default ThemePickerModal