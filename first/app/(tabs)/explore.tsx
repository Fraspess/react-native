import { Image } from 'expo-image';
import { Platform, StyleSheet, View } from 'react-native';

import ParallaxScrollView from "@/components/parallax-scroll-view";
import {ThemedView} from "@/components/themed-view";
import {IconSymbol} from "@/components/ui/icon-symbol";
import * as Yup from "yup";
import {useFormik} from "formik";
import {ICreateCategory} from "@/types/ICreateCategory";
export default function TabTwoScreen() {

    const validScheme = Yup.object({
        name: Yup.string().required("Вкажіть імя категорії"),
        description: Yup.string().required("Вкажіть опис категорії")
    });

    const initialValue: ICreateCategory = {
        name: "",
        description: "",
        image: null
    };

    const onSubmit = (values : ICreateCategory) => {

    }

    const formik = useFormik({
        initialValues: initialValue,
        validationSchema: validScheme,
        onSubmit: onSubmit,
        validateOnChange: true,
        validateOnBlur: true,
    })


  return (
    <ParallaxScrollView
      headerBackgroundColor={{ light: '#D0D0D0', dark: '#353636' }}
      headerImage={
        <IconSymbol
          size={310}
          color="#808080"
          name="chevron.left.forwardslash.chevron.right"
          style={styles.headerImage}
        />
      }>

        <ThemedView>
            <form onSubmit= {formik.handleSubmit}>
                <View className={"mb-6"}>

                </View>
            </form>
        </ThemedView>
    </ParallaxScrollView>
  );
}

const styles = StyleSheet.create({
  headerImage: {
    color: '#808080',
    bottom: -90,
    left: -35,
    position: 'absolute',
  },
  titleContainer: {
    flexDirection: 'row',
    gap: 8,
  },
});
