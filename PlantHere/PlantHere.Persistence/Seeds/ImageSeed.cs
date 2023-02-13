using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantHere.Domain.Aggregate.CategoryAggregate;

namespace PlantHere.Persistence.Seeds
{
    public class ImageSeed : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image { Id = 1, Url = "http://cdn.shopify.com/s/files/1/0284/2450/products/Pachyphytum_Oviferum_-Moonstones_1024x.jpg?v=1571438584", ProductId = 1 },
                            new Image { Id = 2, Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8f/%28MHNT%29_Pachyphytum_oviferum_-_Habitus.jpg/800px-%28MHNT%29_Pachyphytum_oviferum_-_Habitus.jpg", ProductId = 1 },
                            new Image { Id = 3, Url = "https://www.insukuland.com/storage/plants/cover/large/pachyphytum-oviferum-402781.jpg", ProductId = 1 },
                            new Image { Id = 4, Url = "https://i.ytimg.com/vi/uWfjMLX0Xrg/hq720.jpg?sqp=-oaymwEhCK4FEIIDSFryq4qpAxMIARUAAAAAGAElAADIQj0AgKJD&rs=AOn4CLAuw0DF0hhsG765LYz2Nlgb0hwNHw", ProductId = 1 },

                            new Image { Id = 5, Url = "https://cdn11.bigcommerce.com/s-oqm1pc/images/stencil/1280x1280/products/1317/20250/Echeveria_Lola_December__91300.1653687383.jpg?c=2", ProductId = 2 },
                            new Image { Id = 6, Url = "https://m.media-amazon.com/images/I/513pKjTT6KL._AC_SY580_.jpg", ProductId = 2 },
                            new Image { Id = 7, Url = "https://i.pinimg.com/originals/8c/a6/71/8ca671dc56325ab3445488a7b8069dcd.jpg", ProductId = 2 },
                            new Image { Id = 8, Url = "https://www.sukulentler.com/wp-content/uploads/2021/01/99c83396ec520b7bdf153b9da8c48d01.jpg", ProductId = 2 },

                            new Image { Id = 9, Url = "https://worldofsucculents.com/wp-content/uploads/2018/01/Cremnosedum-Little-Gem4.jpg", ProductId = 3 },
                            new Image { Id = 10, Url = "https://cdn.shopify.com/s/files/1/2986/8756/products/cremnosedumlittlegem_12_600x.jpg?v=1610330960", ProductId = 3 },
                            new Image { Id = 11, Url = "https://cdn.shopify.com/s/files/1/2541/4208/products/cremnosedum-little-gem-rare-for-sale-by-succy-crafts-340321_1500x.jpg?v=1671185283", ProductId = 3 },
                            new Image { Id = 12, Url = "https://cdn.shopify.com/s/files/1/0140/1526/6902/products/Cremnosedum_cv._Little_Gem_900x.png?v=1566762171", ProductId = 3 },


                            new Image { Id = 13, Url = "http://cdn.shopify.com/s/files/1/0520/0209/5278/articles/D5FEA48C-6F85-4588-AE00-549DBD94C4F6.png?v=1618008678", ProductId = 4 },
                            new Image { Id = 14, Url = "https://m.media-amazon.com/images/I/512bFkK572L._SX466_.jpg", ProductId = 4 },
                            new Image { Id = 15, Url = "https://wildroots.in/wp-content/uploads/2021/10/Untitled-design-2021-10-13T164954.953.jpg", ProductId = 4 },
                            new Image { Id = 16, Url = "https://cdn.shopify.com/s/files/1/1800/3399/products/calissiacloseup_1024x1024.jpg?v=1666450578", ProductId = 4 },


                            new Image { Id = 17, Url = "https://cdn11.bigcommerce.com/s-oqm1pc/products/3020/images/19308/Haworthia_Super_White__09085.1652214347.555.555.jpg?c=2", ProductId = 5 },
                            new Image { Id = 18, Url = "http://cdn.shopify.com/s/files/1/0284/2450/products/IMG_9955_1024x.jpg?v=1594117399", ProductId = 5 },
                            new Image { Id = 19, Url = "https://thesucculenteclectic.com/wp-content/uploads/2017/11/Haworthia-attentuata-1024x678.jpg", ProductId = 5 },
                            new Image { Id = 20, Url = "https://cdn.shopify.com/s/files/1/0279/8865/6226/products/Planta_Plantique_Haworthia_fasciata1_1024x1024@2x.jpg?v=1601607464", ProductId = 5 },

                            new Image { Id = 21, Url = "https://images.squarespace-cdn.com/content/v1/5968af67414fb590cb8f77e3/1500201738053-SUOSYJDNQ1E5LQ0H9OBR/6991174011_41e1068fe8_b.jpg?format=1500w", ProductId = 6 },
                            new Image { Id = 22, Url = "https://worldofsucculents.com/wp-content/uploads/2017/11/Parodia-leninghausii-Yellow-Tower3-788x591.jpg", ProductId = 6 },
                            new Image { Id = 23, Url = "https://www.picturethisai.com/wiki-image/1080/153815058223202319.jpeg", ProductId = 6 },
                            new Image { Id = 24, Url = "https://www.deco.fr/sites/default/files/styles/article_970x500/public/2022-04/shutterstock_2099004502.jpg?itok=6eE1BHrd", ProductId = 6 },


                            new Image { Id = 25, Url = "https://i.ebayimg.com/images/g/uj0AAOSwtG9bInf1/s-l1600.jpg", ProductId = 7 },
                            new Image { Id = 26, Url = "https://p0.pikist.com/photos/451/999/orchid-tropical-flowers-greenhouses-orchidophilia-colour-yellow-and-brown-tiger-beautiful-fascinating-mysterious.jpg", ProductId = 7 },
                            new Image { Id = 27, Url = "https://bluenanta.com/static/utils/images/species/spc_000147120_000023395.jpg", ProductId = 7 },
                            new Image { Id = 28, Url = "https://upload.wikimedia.org/wikipedia/commons/e/ec/Paphiopedilum_henryanum_Orchi_001.jpg", ProductId = 7 },

                            new Image { Id = 29, Url = "https://cicekambari.com/wp-content/uploads/2020/12/beyaz-orkide-cicegi-e1607005633825.jpg", ProductId = 8 },
                            new Image { Id = 30, Url = "https://adanavipcicek.com/img/urunler/1106/orginal/dekoratif-camda-yapay-beyaz-orkide-adana-vip-cicekcilik1.jpg", ProductId = 8 },
                            new Image { Id = 31, Url = "https://cicekambari.com/wp-content/uploads/2020/12/beyaz-orkide-1024x640.jpg", ProductId = 8 },
                            new Image { Id = 32, Url = "https://cicekambari.com/wp-content/uploads/2020/12/beyaz-orkide-hakkinda-e1607005655293.jpg", ProductId = 8 },

                            new Image { Id = 33, Url = "https://cdn.shopify.com/s/files/1/0073/7191/5333/products/gabriella-plants-4-spider-plant-variegated-regular-variegated-30252499173563.jpg?v=1633545657", ProductId = 9 },
                            new Image { Id = 34, Url = "https://3.bp.blogspot.com/-eJ3JQzLLMGw/W1tUY-anBdI/AAAAAAACtoU/KFsUaeNtdD0Kd3jfu-tpinL48Mgtd9PrgCKgBGAs/s1600/IMG_6939.JPG", ProductId = 9 },
                            new Image { Id = 35, Url = "https://evterapisi.com/wp-content/uploads/2021/02/kurdele-cicegi-5.jpg", ProductId = 9 },
                            new Image { Id = 36, Url = "https://i.nefisyemektarifleri.com/2020/08/19/kurdele-cicegi-bakimi-cogaltilmasi-faydalari-3.jpg", ProductId = 9 },


                            new Image { Id = 37, Url = "https://images.squarespace-cdn.com/content/v1/56091b78e4b09e2b03426d22/1584442195074-Z235QWUQ77F10KFUZ4F8/Aeonium+Laxum.jpg?format=2500w", ProductId = 10 },
                            new Image { Id = 38, Url = "https://i.pinimg.com/originals/58/c3/db/58c3db9c37a7048988a1897e1c63b9a4.jpg", ProductId = 10 },
                            new Image { Id = 39, Url = "https://i.redd.it/ya94ttfr1lw71.jpg", ProductId = 10 },
                            new Image { Id = 40, Url = "https://i.pinimg.com/originals/2d/dd/56/2ddd56dc9c5e25442cb449916f682327.jpg", ProductId = 10 },

                            new Image { Id = 41, Url = "https://www.cocodema.com/wp-content/uploads/2019/01/pilea_edit.jpg", ProductId = 11 },
                            new Image { Id = 42, Url = "https://images.immediate.co.uk/production/volatile/sites/10/2021/03/2048x1365-Pilea-Peperomioides-SEO-GettyImages-1225860485-79b134d.jpg?resize=768,574", ProductId = 11 },
                            new Image { Id = 43, Url = "https://www.botanikamo.com/content/images/gallery/ayakl%C4%B1%20saks%C4%B1da%20dev%20pilea%20.JPG", ProductId = 11 },
                            new Image { Id = 44, Url = "https://yesilmimar.net/wp-content/uploads/2022/08/Pilea-Peperomioides-Para-Bitkisi-Bakimi-ve-Cogaltilmasi-2-768x1024.jpg", ProductId = 11 },

                            new Image { Id = 45, Url = "https://cdn.diys.com/wp-content/uploads/2020/10/Watermelon-Peperomia-Peperomia-argyreia.jpg", ProductId = 12 },
                            new Image { Id = 46, Url = "https://balconygardenweb-lhnfx0beomqvnhspx.netdna-ssl.com/wp-content/uploads/2020/04/How-to-Grow-Watermelon-Peperomia.jpg", ProductId = 12 },
                            new Image { Id = 47, Url = "https://i.etsystatic.com/21427386/r/il/448bed/2902621052/il_1080xN.2902621052_d3e4.jpg", ProductId = 12 },
                            new Image { Id = 48, Url = "https://cdn.hortzone.com/wp-content/uploads/2022/01/Watermelon-Peperomia-Peperomia-argyreia-in-hanging-Baskets.jpg", ProductId = 12 },


                            new Image { Id = 49, Url = "https://worldofsucculents.com/wp-content/uploads/2013/12/Monanthes-polyphylla1.jpg", ProductId = 13 },
                            new Image { Id = 50, Url = "https://www.sukulentler.com/wp-content/uploads/2021/01/117363/monanthes-polyphylla-sukulent.jpg", ProductId = 13 },
                            new Image { Id = 51, Url = "https://cdn.shopify.com/s/files/1/0140/1526/6902/products/Monanthes_polyphylla1_900x.png?v=1561203971", ProductId = 13 },
                            new Image { Id = 52, Url = "https://cdn.shopify.com/s/files/1/0271/9432/7138/products/images_30_839f9e90-50ce-43ec-bb88-b3c5ae5a2acc_554x.jpg?v=1618303310", ProductId = 13 },


                            new Image { Id = 53, Url = "https://i.pinimg.com/736x/98/b9/e6/98b9e6006e0c9e67b7f6dda54bc3d7d7.jpg", ProductId = 14 },
                            new Image { Id = 54, Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTu49BoGmXycNOuCuZtiXug0kqvP-phwEFOY1a04CXYji5Tym4TtVYUuN0SRqjpqUkvtOo&usqp=CAU", ProductId = 14 },
                            new Image { Id = 55, Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRsp6SpeuYLRUOwZv815BKJheqhMqmTEfoIQw&usqp=CAU", ProductId = 14 },
                            new Image { Id = 56, Url = "https://cdn.shopify.com/s/files/1/1758/4539/products/il_570xN.1649385779_t0pv_800x.jpg?v=1543327830", ProductId = 14 },

                            new Image { Id = 57, Url = "https://media.giromagi.com/prodotti/full/202105/IMG_20210511_104811.jpg", ProductId = 15 },
                            new Image { Id = 58, Url = "https://cdn.shopify.com/s/files/1/2203/9263/products/641f5023dcedba92d7bf90710069e335.jpg?v=1571616461", ProductId = 15 },
                            new Image { Id = 59, Url = "https://debraleebaldwin.com/wp-content/uploads/IMG_9400.jpg", ProductId = 15 },
                            new Image { Id = 60, Url = "https://www.panoramaweb.com.mx/u/fotografias/m/2022/10/12/f608x342-38506_68229_0.jpg", ProductId = 15 },

                            new Image { Id = 61, Url = "https://static1.s123-cdn-static-a.com/uploads/1826974/2000_603ce1ec4b95d.jpg", ProductId = 16 },
                            new Image { Id = 62, Url = "https://st4.depositphotos.com/19966820/24306/i/450/depositphotos_243065704-stock-photo-barrel-shaped-green-leaves-with.jpg", ProductId = 16 },
                            new Image { Id = 63, Url = "https://cdn.dsmcdn.com/ty570/product/media/images/20221019/21/197528384/333594503/1/1_org_zoom.jpg", ProductId = 16 },
                            new Image { Id = 64, Url = "https://feelslike-home.co.uk/wp-content/uploads/2020/12/131508647_714870976128126_8510697134910715586_n-scaled.jpg", ProductId = 16 },

                            new Image { Id = 65, Url = "https://cdn.shopify.com/s/files/1/0789/1541/products/FC40A1DF_1024x1024.jpg?v=1658344259", ProductId = 17 },
                            new Image { Id = 66, Url = "https://images.squarespace-cdn.com/content/v1/57543493859fd0803020890f/1624972713842-RYKPNQR13CIS9JEVPKQQ/20210624_132443.jpg?format=1000w", ProductId = 17 },
                            new Image { Id = 67, Url = "https://www.cocaflora.com/userdata/public/gfx/13964/Senecio-herreianus---Starzec---Sznur-korali.jpg", ProductId = 17 },
                            new Image { Id = 68, Url = "https://m.media-amazon.com/images/I/71T1PQmmVWL._AC_SL1000_.jpg", ProductId = 17 },

                            new Image { Id = 69, Url = "https://live.staticflickr.com/65535/52025117074_dc22e3621a_b.jpg", ProductId = 18 },
                            new Image { Id = 70, Url = "https://www.insukuland.com/storage/plants/cover/large/orbea-variegata-991162.jpg", ProductId = 18 },
                            new Image { Id = 71, Url = "https://cdn.shopify.com/s/files/1/0284/2450/products/Orbea-variegata-Stapelia-variegata_800x.jpg?v=1571438671", ProductId = 18 },
                            new Image { Id = 72, Url = "https://s.ecrater.com/stores/59305/5cec3a1f7a63f_59305b.jpg", ProductId = 18 },

                            new Image { Id = 73, Url = "http://cdn.shopify.com/s/files/1/0268/0681/2787/products/20220607_121700_1200x1200.jpg?v=1661779056", ProductId = 19 },
                            new Image { Id = 74, Url = "https://cdn.shopify.com/s/files/1/0268/0681/2787/products/20220510_144542_6243ab15-63ea-4599-a7ea-1a2c1b0d245f_grande.jpg?v=1661779056", ProductId = 19 },
                            new Image { Id = 75, Url = "https://www.kenthurstsucculents.com.au/wp-content/uploads/2018/08/Sedum-Lucidum-2.jpg", ProductId = 19 },
                            new Image { Id = 76, Url = "https://i.pinimg.com/736x/59/7c/72/597c720e0b54fba809471ab7975e6937--passion-horticulture.jpg", ProductId = 19 },

                            new Image { Id = 77, Url = "https://cdn11.bigcommerce.com/s-oqm1pc/images/stencil/1280x1280/products/1492/4654/echeveria_perle_von_august__83133.1646858054.jpg?c=2", ProductId = 20 },
                            new Image { Id = 78, Url = "https://i.etsystatic.com/13687258/r/il/cc2011/3509113567/il_570xN.3509113567_8n9d.jpg", ProductId = 20 },
                            new Image { Id = 79, Url = "https://www.sublimesucculents.com/wp-content/uploads/2019/04/7-echeveria-perle.jpg", ProductId = 20 },
                            new Image { Id = 80, Url = "https://succulentsnetwork.com/wp-content/uploads/2020/05/Screenshot-2020-11-07-at-15.48.57.png", ProductId = 20 },


                            new Image { Id = 81, Url = "https://i.pinimg.com/736x/fe/a4/ee/fea4ee293d51d97d361981455a409039.jpg", ProductId = 21 },
                            new Image { Id = 82, Url = "https://i.pinimg.com/originals/06/64/62/066462828cc474586f4bbc7762075066.jpg", ProductId = 21 },
                            new Image { Id = 83, Url = "https://qph.cf2.quoracdn.net/main-qimg-86086f72424e6dde31d4ed232d778759-lq", ProductId = 21 },
                            new Image { Id = 84, Url = "https://garden-tags-live.s3-accelerate.amazonaws.com/112884_prettyandprickle_1590158587568_1080.jpeg", ProductId = 21 }

                            );

        }
    }
}
